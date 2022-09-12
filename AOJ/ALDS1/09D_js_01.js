// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_D
"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const fs_1 = __importDefault(require("fs"));
const input_str = fs_1.default.readFileSync(process.env.NODE_ENV === 'debug' ? stdin : process.stdin.fd, 'utf8');
class Input {
  constructor(str) {
    this.index = 0;
    this.inputs = str.split(/\s+/);
  }
  number() {
    return Number(this.inputs[this.index++]);
  }
  word() {
    return this.inputs[this.index++];
  }
}
const input = new Input(input_str);
const INT = Math.floor;
const n = input.number();
const A = Array(n);
for (let i = 0; i < n; i++) {
  A[i] = input.number();
}
A.sort((a, b) => b - a);
const indices = Array(n + 1);
for (let i = 1; i <= n; i++) {
  indices[i] = i;
}
let tail = n;
while (tail > 1) {
  const tmp = indices[1];
  indices[1] = indices[tail];
  indices[tail] = tmp;
  tail--;
  const route = [];
  let idx = tail;
  while (idx > 1) {
    route.push(idx);
    idx = INT(idx / 2);
  }
  let src = 1;
  while (route.length > 0) {
    const dest = route.pop();
    if (dest) {
      const tmp = indices[src];
      indices[src] = indices[dest];
      indices[dest] = tmp;
      src = dest;
    }
  }
}
const result = Array(n);
for (let i = 0; i < n; i++) {
  result[indices[n - i] - 1] = A[i];
}
console.log(result.join(' '));
//# sourceMappingURL=aoj.js.map
