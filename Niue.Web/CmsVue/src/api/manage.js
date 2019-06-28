import { axios } from '@/utils/request'

const api = {
  getUsers: '/user/getUsers',
  addUser: '/user/addUser',
  editUser: '/user/editUser',
  activeUser: '/user/activeUser',
  deleteUser: '/user/deleteUser',
  retain: '/retain/retain'
}

export default api

export function getUserList (parameter) {
  return axios({
    url: api.getUsers,
    method: 'post',
    data: parameter
  })
}

export function addUser (parameter) {
  return axios({
    url: api.addUser,
    method: 'post',
    data: parameter
  })
}

export function editUser (parameter) {
  return axios({
    url: api.editUser,
    method: 'post',
    data: parameter
  })
}

export function activeUser (parameter) {
  return axios({
    url: api.activeUser,
    method: 'post',
    data: parameter
  })
}

export function deleteUser (parameter) {
  return axios({
    url: api.deleteUser,
    method: 'post',
    data: parameter
  })
}
