<template>
  <div class="container">
    <div class="card text-center">
      <div class="card-header">
        RPC Application Test
      </div>
      <div class="card-body">
        <form v-on:submit="handleAction">
          <div class="mb-3">
            <span>User Name</span>
            <input name="userName" :value="userName" class="form-control" @input="$emit('update:userName', $event.target.value)"/>
          </div>
          <div class="mb-3">
            <span>Password</span>
            <input name="password" :value="password" class="form-control" @input="$emit('update:password', $event.target.value)"/>
          </div>
          <div class="mb-3">
            <button class="btn btn-primary" id="login" type="submit" @click="setButtonId('Login')" :data-id="id">Login</button>&nbsp;
            <button class="btn btn-primary" id="create" type="submit" @click="setButtonId('Create')" :data-id="id">Create</button>&nbsp;
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script setup>
import axios from 'axios';
import { defineProps, ref } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const props = defineProps({
  userName: String,
  password: String,
  id: String,
});
const buttonId = ref(null);

const handleAction = async (event) => {
  event.preventDefault();
  const payload = {
    userName: event.target.elements.userName.value,
    password: event.target.elements.password.value,
  };
  console.log(payload);

  try {
      console.log(payload)
      const response = await axios.post(`https://localhost:7138/api/Calculator/${buttonId.value}`,payload);

      console.log(response.data)
      if (response.data) {
          router.push({ path: '/Calculator', query: { userName: payload.userName } });
      }

  } catch (error) {
      console.log(error)
  }
};

const setButtonId = (id) => {
  buttonId.value = id
  console.log(id);
};

</script>
