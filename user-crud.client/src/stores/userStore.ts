import { defineStore } from 'pinia'
import { users, nationalities } from '../services/api'

type User = {
  id?: string
  firstName: string
  lastName: string
  nationality?: string
  email?: string
  phone?: string
  profession?: string
  birthDate?: string
  salary?: number
}

export const useUserStore = defineStore('user', {
  state: () => ({
    list: [] as User[],
    total: 0,
    // pagination removed - using non-paginated endpoint
    nationalities: [] as string[]
  }),
  actions: {
    async fetch() {
      // Use the non-paginated endpoint to fetch all users
      const res = await users.getAll()
      // Cast response to User[] to avoid implicit any
      const data = res.data as User[]
      this.list = data
      this.total = Array.isArray(data) ? data.length : 0
      // Keep pagination state but reset to first page
      return
    },
    async loadNationalities() {
      const res = await nationalities.getAll()
      this.nationalities = res.data
    }
  }
})
