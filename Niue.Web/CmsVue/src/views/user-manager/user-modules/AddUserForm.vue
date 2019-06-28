<template>
  <a-modal
    title="新建用户"
    :width="640"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="用户名" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="formRules.userName" />
        </a-form-item>
        <a-form-item label="密码" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="formRules.pwd" />
        </a-form-item>
        <a-form-item label="姓名" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="formRules.name" />
        </a-form-item>
        <a-form-item label="手机号" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="formRules.mobile" />
        </a-form-item>
        <a-form-item label="用户类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-radio-group buttonStyle="solid" v-decorator="formRules.userType">
            <a-radio-button value="1">系统用户</a-radio-button>
            <a-radio-button value="2">代理商用户</a-radio-button>
          </a-radio-group>
        </a-form-item>
        <a-form-item label="电子邮箱" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-input v-decorator="formRules.emailAddress" />
        </a-form-item>
        <a-form-item label="状态" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-switch checkedChildren="正常" unCheckedChildren="禁用" v-decorator="formRules.isActive"/>
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
import { addUser } from '@/api/manage'

export default {
  name: 'AddUserForm',
  data () {
    return {
      labelCol: {
        xs: { span: 24 },
        sm: { span: 7 }
      },
      wrapperCol: {
        xs: { span: 24 },
        sm: { span: 13 }
      },
      visible: false,
      confirmLoading: false,

      form: this.$form.createForm(this),
      formRules: {
        userName: [ 'userName', { rules: [ { required: true, max: 32, message: '请输入最多32个字符的用户名！' } ] } ],
        pwd: [ 'pwd', { rules: [ { required: true, min: 6, max: 18, message: '请输入6-18个字符的密码！' } ] } ],
        name: [ 'name', { rules: [ { required: true, max: 32, message: '请输入最多32个字符的姓名！' } ] } ],
        mobile: [ 'mobile', { rules: [ { required: true, max: 20, message: '请输入最多20个字符的手机号！' } ] } ],
        userType: [ 'userType', { initialValue: '1', rules: [ { required: true, message: '请选择用户类型！' } ] } ],
        emailAddress: [ 'emailAddress' ],
        isActive: [ 'isActive', { initialValue: true, valuePropName: 'checked', rules: [ { required: true } ] } ]
      }
    }
  },
  methods: {
    add () {
      this.visible = true
    },
    handleSubmit () {
      const { form: { validateFields } } = this
      this.confirmLoading = true
      validateFields((errors, values) => {
        if (!errors) {
          console.log('values', values)
          addUser(values)
            .then(res => {
              this.visible = false
              this.confirmLoading = false
              if (res.result.code === 0) {
                this.$message.info(`${res.result.message}`)
                this.$emit('ok', res.result)
              } else {
                this.$message.error(`${res.result.message}`)
              }
            })
            .catch(err => {
              console.log('error', err)
              this.confirmLoading = false
              this.$message.error(`${err}`)
            })
        } else {
          this.confirmLoading = false
        }
      })
    },
    handleCancel () {
      this.visible = false
    }
  }
}
</script>
