<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { users } from '../services/api'
import { useRouter } from 'vue-router'
import { useUserStore } from '../stores/userStore'

const router = useRouter()
const store = useUserStore()
const model = ref({ firstName: '', lastName: '', nationality: '', email: '', phone: '', profession: '', birthDate: '', salary: 0 })

onMounted(async () => {
  if (store.nationalities.length === 0) await store.loadNationalities()
})

const save = async () => {
  await users.create(model.value)
  await store.fetch()
  router.push('/')
}
</script>

<template>
  <v-container>
    <v-card elevation="2">
      <v-card-title>Crear Usuario</v-card-title>
      <v-card-text>
        <v-form>
          <v-row>
            <v-col cols="12" md="6">
              <v-text-field v-model="model.firstName" label="Nombre" required />
            </v-col>
            <v-col cols="12" md="6">
              <v-text-field v-model="model.lastName" label="Apellido" required />
            </v-col>

            <v-col cols="12" md="6">
              <v-select :items="store.nationalities" v-model="model.nationality" label="Nacionalidad" />
            </v-col>

            <v-col cols="12" md="6">
              <v-text-field v-model="model.email" label="Correo" type="email" />
            </v-col>

            <v-col cols="12" md="4">
              <v-text-field v-model="model.phone" label="Teléfono" />
            </v-col>

            <v-col cols="12" md="4">
              <v-text-field v-model="model.profession" label="Profesión" />
            </v-col>

            <v-col cols="12" md="4">
              <v-text-field v-model="model.salary" label="Salario" type="number" />
            </v-col>

            <v-col cols="12" md="6">
              <v-text-field v-model="model.birthDate" label="Fecha Nacimiento" type="date" />
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="primary" @click="save">Guardar</v-btn>
        <router-link to="/"><v-btn text>Cancelar</v-btn></router-link>
      </v-card-actions>
    </v-card>
  </v-container>
</template>
