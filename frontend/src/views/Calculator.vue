<template>
  <div class="container">
    <h1>Welcome User, {{ userName }}</h1>
    <div class="row">
      <div class="col-10">
        <div class="calculator">
          <div class="display">{{ current || '0' }}</div>
          <div @click="clear" class="btn" id="c">C</div>
          <div @click="setOperator(3)" class="btn operator">÷</div>
          <div @click="append('7')" class="btn">7</div>
          <div @click="append('8')" class="btn">8</div>
          <div @click="append('9')" class="btn">9</div>
          <div @click="setOperator(2)" class="btn operator">x</div>
          <div @click="append('4')" class="btn">4</div>
          <div @click="append('5')" class="btn">5</div>
          <div @click="append('6')" class="btn">6</div>
          <div @click="setOperator(1)" class="btn operator">-</div>
          <div @click="append('1')" class="btn">1</div>
          <div @click="append('2')" class="btn">2</div>
          <div @click="append('3')" class="btn">3</div>
          <div @click="setOperator(0)" class="btn operator">+</div>
          <div @click="append('0')" class="btn zero">0</div>
          <div @click="dot" class="btn">.</div>
          <div @click="equal" class="btn operator">=</div>
        </div>
      </div>
      <div class="col-4" style="margin-top: 50px;">
        <table class="table table-bordered table-hover table-striped table-lg">
          <thead>
            <tr>
              <th>User Name</th>
              <th>Duration in ms</th>
              <th>Number 1</th>
              <th>Number 2</th>
              <th>Result</th>
              <th>Ip</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(row, index) in result" :key="index">
              <td>{{ row.userName }}</td>
              <td>{{ row.duration }}</td>
              <td>{{ row.number1 }}</td>
              <td>{{ row.number2 }}</td>
              <td>{{ row.result }}</td>
              <td>{{ row.ip }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

  
<script setup>
import axios from 'axios';
import { useRoute } from 'vue-router';
import { ref } from 'vue';

const result = ref([]); // Initialize result as an empty array
const route = useRoute();
const userName = route.query.userName;

const previous = ref(null);
const current = ref('');
const operator = ref(null);
const operatorClicked = ref(false);

const clear = () => {
  current.value = '';
};

const append = (number) => {
  if (operatorClicked.value) {
    current.value = '';
    operatorClicked.value = false;
  }
  current.value = `${current.value}${number}`;
};

const dot = () => {
  if (current.value.indexOf('.') === -1) {
    append('.');
  }
};

const setOperator = (op) => {
  operator.value = op;
  setPrevious();
};

const setPrevious = () => {
  previous.value = current.value;
  operatorClicked.value = true;
};

const equal = async () => {
  const calculation = {
    number1: previous.value,
    number2: current.value,
    task: operator.value,
    userName: userName,
  };

  previous.value = null;

  try {
    const response = await axios.post('https://localhost:7138/api/Calculator/Calculator', calculation);
    console.log(response.data);

    result.value.push(response.data); // Add the response data to the result array

    current.value = response.data.result;
  } catch (error) {
    console.log(error);
  }
};
</script>
  <style scoped>
.calculator {
  margin: 0 auto;
  width: 400px;
  font-size: 40px;
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  grid-auto-rows: minmax(40px, auto);
}

.display {
  grid-column: 1 / 5;
  background-color: #575353;
  color: white;
}

.zero {
  grid-column: 1 / 3;
}
#c {
  grid-column: 1 / 4;
  background-color: rgb(66, 184, 131);
  color: rgb(0, 0, 0);
}

.btn {
    color: rgb(53, 73, 94);
  border: 2px solid #101520;
}

.operator {
  background-color: rgb(66, 184, 131);
  color: rgb(53, 73, 94);

}
.table-lg {
  width: 300%; /* Adjust the width as per your preference */
}

</style>