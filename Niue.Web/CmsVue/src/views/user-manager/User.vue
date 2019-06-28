<template>
  <a-card :bordered="false">
    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="48">
          <a-col :md="8" :sm="24">
            <a-form-item label="用户名/手机号/姓名">
              <a-input v-model="queryParam.key" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="用户类型">
              <a-select v-model="queryParam.userType" placeholder="请选择" default-value="0">
                <a-select-option value="0">全部</a-select-option>
                <a-select-option value="1">系统用户</a-select-option>
                <a-select-option value="2">代理商用户</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <template v-if="advanced">
            <a-col :md="8" :sm="24">
              <a-form-item label="电子邮箱">
                <a-input v-model="queryParam.emailAddress" placeholder=""/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="使用状态">
                <a-select v-model="queryParam.isActive" placeholder="请选择" default-value="0">
                  <a-select-option value="0">全部</a-select-option>
                  <a-select-option value="1">正常</a-select-option>
                  <a-select-option value="2">禁用</a-select-option>
                </a-select>
              </a-form-item>
            </a-col>
          </template>
          <a-col :md="!advanced && 8 || 24" :sm="24">
            <span class="table-page-search-submitButtons" :style="advanced && { float: 'right', overflow: 'hidden' } || {} ">
              <a-button type="primary" @click="$refs.table.refresh(true)">查询</a-button>
              <a-button style="margin-left: 8px" @click="() => queryParam = {}">重置</a-button>
              <a @click="toggleAdvanced" style="margin-left: 8px">
                {{ advanced ? '收起' : '展开' }}
                <a-icon :type="advanced ? 'up' : 'down'"/>
              </a>
            </span>
          </a-col>
        </a-row>
      </a-form>
    </div>

    <div class="table-operator">
      <a-button type="primary" icon="plus" @click="$refs.addUserForm.add()">新建</a-button>
    </div>

    <s-table
      ref="table"
      size="default"
      :columns="columns"
      :data="loadData"
      showPagination="auto"
    >
      <span slot="serial" slot-scope="text, record, index">
        {{ index + 1 }}
      </span>
      <span slot="userType" slot-scope="text">
        {{ text | userTypeFilter }}
      </span>
      <span slot="isActive" slot-scope="text">
        <a-badge :status="text | statusTypeFilter" :text="text | statusFilter" />
      </span>

      <span slot="action" slot-scope="text, record">
        <template>
          <a @click="handleEdit(record)">编辑</a>
          <a-divider type="vertical" />
          <a @click="handleActive(record)">{{ record.isActive ? '禁用' : '启用' }}</a>
          <a-divider type="vertical" />
          <a @click="handleDelete(record)">删除</a>
        </template>
      </span>
    </s-table>

    <add-user-form ref="addUserForm" @ok="handleOk" />
    <edit-user-form ref="editUserForm" @ok="handleOk" />
  </a-card>
</template>

<script>
import moment from 'moment'
import { STable, Ellipsis } from '@/components'
import { getUserList, activeUser, deleteUser } from '@/api/manage'
import AddUserForm from './user-modules/AddUserForm'
import EditUserForm from './user-modules/EditUserForm'

const userTypeMap = [ '系统用户', '代理商用户' ]

export default {
  name: 'UserList',
  components: {
    STable,
    Ellipsis,
    AddUserForm,
    EditUserForm
  },
  data () {
    return {
      mdl: {},
      // 高级搜索 展开/关闭
      advanced: false,
      // 查询参数
      queryParam: {},
      // 表头
      columns: [
        {
          title: '#',
          scopedSlots: { customRender: 'serial' }
        },
        {
          title: '用户名',
          dataIndex: 'userName',
          sorter: true
        },
        {
          title: '姓名',
          dataIndex: 'name',
          sorter: true
        },
        {
          title: '手机号',
          dataIndex: 'mobile'
        },
        {
          title: '用户类型',
          dataIndex: 'userType',
          scopedSlots: { customRender: 'userType' }
        },
        {
          title: '电子邮箱',
          dataIndex: 'emailAddress'
        },
        {
          title: '状态',
          dataIndex: 'isActive',
          scopedSlots: { customRender: 'isActive' }
        },
        {
          title: '最后登录时间',
          dataIndex: 'lastLoginTime',
          sorter: true
        },
        {
          title: '操作',
          dataIndex: 'action',
          width: '150px',
          scopedSlots: { customRender: 'action' }
        }
      ],
      // 加载数据方法 必须为 Promise 对象
      loadData: parameter => {
        console.log('loadData.parameter', parameter)
        return getUserList(Object.assign(parameter, this.queryParam))
          .then(res => {
            return res.result
          })
      }
    }
  },
  filters: {
    userTypeFilter (text) {
      return text > 0 ? userTypeMap[text - 1] : ''
    },
    statusFilter (text) {
      return text === true ? '正常' : '禁用'
    },
    statusTypeFilter (text) {
      return text === true ? 'success' : 'default'
    }
  },
  methods: {
    handleEdit (record) {
      console.log('record', record)
      this.$refs.editUserForm.edit(record)
    },
    handleActive (record) {
      const _this = this
      this.$confirm({
        title: '警告',
        content: `真的要${record.isActive ? '禁用' : '启用'} ${record.userName} 吗?`,
        okText: record.isActive ? '禁用' : '启用',
        okType: record.isActive ? 'danger' : 'success',
        cancelText: '取消',
        onOk () {
          record.isActive = !record.isActive
          return activeUser(record)
            .then(res => {
              if (res.result.code === 0) {
                _this.$message.info(`${res.result.message}`)
                _this.$refs.table.refresh(true)
              } else {
                _this.$message.error(`${res.result.message}`)
              }
            })
            .catch(err => {
              console.log('error', err)
              _this.$message.error(`${err}`)
            })
        },
        onCancel () {
          console.log('Cancel')
        }
      })
    },
    handleDelete (record) {
      const _this = this
      this.$confirm({
        title: '警告',
        content: `真的要删除 ${record.userName} 吗?`,
        okText: '删除',
        okType: 'danger',
        cancelText: '取消',
        onOk () {
          return deleteUser(record)
            .then(res => {
              if (res.result.code === 0) {
                _this.$message.info(`${res.result.message}`)
                _this.$refs.table.refresh(true)
              } else {
                _this.$message.error(`${res.result.message}`)
              }
            })
            .catch(err => {
              console.log('error', err)
              _this.$message.error(`${err}`)
            })
        },
        onCancel () {
          console.log('Cancel')
        }
      })
    },
    handleOk () {
      this.$refs.table.refresh()
    },
    toggleAdvanced () {
      this.advanced = !this.advanced
    },
    resetSearchForm () {
      this.queryParam = {
        date: moment(new Date())
      }
    }
  }
}
</script>
