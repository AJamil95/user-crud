import axios from 'axios'

const BASE = import.meta.env.VITE_API_BASE || ''

export const api = axios.create({
  baseURL: BASE,
  headers: { 'Content-Type': 'application/json' }
})

export const users = {
  getAll: () => api.get('/api/users'),
  getPaginated: (page: number, size: number) => api.get(`/api/users/paginated?pageNumber=${page}&pageSize=${size}`),
  get: (id: string) => api.get(`/api/users/${id}`),
  create: (data: any) => api.post('/api/users', data),
  update: (id: string, data: any) => api.put(`/api/users/${id}`, data),
  remove: (id: string) => api.delete(`/api/users/${id}`)
}

export const nationalities = {
  getAll: () => api.get('/api/nationalities')
}
