<script setup lang="ts">
  import { onMounted, computed, ref } from 'vue'
  import { useUserStore } from '../stores/userStore'
  import { users } from '../services/api'
  import { useRouter } from 'vue-router'

  const store = useUserStore()
  const router = useRouter()

  const headers = ref([
    { title: 'Nombre', key: 'firstName' },
    { title: 'Apellido', key: 'lastName' },
    { title: 'Nacionalidad', key: 'nationality' },
    { title: 'Correo', key: 'email' },
    { title: 'Teléfono', key: 'phone' },
    { title: 'Profesión', key: 'profession' },
    { title: 'Fecha Nacimiento', key: 'birthDate' },
    { title: 'Salario', key: 'salary' },
    { title: 'Accciones', key: 'actions' }
  ])

  const loading = ref(false)

  onMounted(async () => {
    loading.value = true
    await store.fetch()
    await store.loadNationalities()
    loading.value = false
  })

  const remove = async (id: string) => {
    const confirmed = confirm('¿Eliminar usuario?')
    if (!confirmed) return
    await users.remove(id)
    await store.fetch()
  }

  const edit = (id: string) => {
    router.push(`/edit/${id}`)
  }

  const formatDate = (value?: string) => {
    if (!value) return '-'
    const datePart = value.split('T')[0]
    const parts = datePart.split('-')
    if (parts.length === 3) {
      const y = Number(parts[0])
      const m = Number(parts[1]) - 1
      const d = Number(parts[2])
      const dt = new Date(y, m, d)
      return dt.toLocaleDateString()
    }
    const parsed = new Date(value)
    if (isNaN(parsed.getTime())) return '-'
    return parsed.toLocaleDateString()
  }
</script>

<template>
  <v-card flat>
    <template #title>
      <div class="d-flex align-center justify-space-between w-100">
        <span class="text-h6"><strong>Gestión de Usuarios</strong></span>
        <router-link to="/create"> <v-btn color="primary" style="font-size: 16px"> <v-icon style="font-size: 16px">mdi-plus</v-icon> Agregar </v-btn> </router-link>
      </div>
    </template>
    <v-card-text>
      <v-data-table :items="store.list"
                    :headers="headers"
                    :loading="loading"
                    hide-default-footer
                    :items-per-page="-1">
        <template #item.birthDate="{ item }">
          <span>{{ formatDate(item.birthDate) }}</span>
        </template>

        <template #item.salary="{ item }">
          <span>{{ item.salary ? Number(item.salary).toFixed(2) : '-' }}</span>
        </template>

        <template #item.actions="{ item }">
          <v-btn size="small" color="warning" @click="edit(item.id)" class="mr-2">
            <v-icon size="small">mdi-pencil</v-icon>
          </v-btn>
          <v-btn size="small" color="error" @click="remove(item.id)">
            <v-icon size="small">mdi-delete</v-icon>
          </v-btn>
        </template>
      </v-data-table>
    </v-card-text>
  </v-card>
</template>
