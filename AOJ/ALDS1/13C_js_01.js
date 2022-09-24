// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_C/review/5128885/nanana1o/JavaScript
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
const N = 4;
const N2 = 16;
const LIMIT = 100;
const dx = [0, -1, 0, 1];
const dy = [1, 0, -1, 0];
const dir = ['r', 'u', 'l', 'd'];
const rev = [2, 3, 0, 1];
const immovable = [];
const MDT = [];
class Puzzle {
  constructor() {
    this.f = Array(N2);
    this.space = 0;
    this.MD = 0;
  }
  clone() {
    const r = new Puzzle();
    for (let i = 0; i < N2; i++) {
      r.f[i] = this.f[i];
    }
    r.space = this.space;
    r.MD = this.MD;
    return r;
  }
}
let state;
let limit;
let path = Array(LIMIT);
function getAllMD(pz) {
  let sum = 0;
  for (let i = 0; i < N2; i++) {
    if (pz.f[i] == N2) {
      continue;
    }
    sum += MDT[i][pz.f[i] - 1];
  }
  return sum;
}
function isSolved() {
  for (let i = 0; i < N2; i++) {
    if (state.f[i] != i + 1) {
      return false;
    }
  }
  return true;
}
function dfs(depth, prev) {
  if (state.MD == 0) {
    return true;
  }
  if (depth + state.MD > limit) {
    return false;
  }
  const sx = INT(state.space / N);
  const sy = state.space % N;
  let tmp;
  for (let r = 0; r < 4; r++) {
    if (rev[r] == prev || immovable[state.space][r]) {
      continue;
    }
    const tx = sx + dx[r];
    const ty = sy + dy[r];
    tmp = state.clone();
    state.space = tx * N + ty;
    const t = state.f[state.space] - 1;
    state.MD -= MDT[state.space][t];
    state.MD += MDT[tmp.space][t];
    state.f[tmp.space] = state.f[state.space];
    state.f[state.space] = 16;
    if (dfs(depth + 1, r)) {
      path[depth] = r;
      return true;
    }
    state = tmp;
  }
  return false;
}
function iterative_deepening(initial) {
  initial.MD = getAllMD(initial);
  let limit0 = initial.MD;
  if (MDT[15][initial.space] % 2 != limit0 % 2) {
    limit0 += 1;
  }
  for (limit = limit0; limit <= LIMIT; limit += 2) {
    state = initial.clone();
    if (dfs(0, -1)) {
      let ans = '';
      for (let i = 0; i < limit; i++) {
        ans += dir[path[i]];
      }
      return ans;
    }
  }
  return 'unsolvable';
}
function main() {
  for (let i = 0; i < N2; i++) {
    MDT.push(Array(N));
    for (let j = 0; j < N2; j++) {
      MDT[i][j] = Math.abs(INT(i / N) - INT(j / N)) + Math.abs((i % N) - (j % N));
    }
  }
  for (let i = 0; i < N2; i++) {
    immovable.push(Array(4));
    const ix = INT(i / N);
    const iy = i % N;
    for (let j = 0; j < 4; j++) {
      const tx = ix + dx[j];
      const ty = iy + dy[j];
      immovable[i][j] = tx < 0 || ty < 0 || tx >= N || ty >= N;
    }
  }
  const initial = new Puzzle();
  for (let i = 0; i < N2; i++) {
    initial.f[i] = input.number();
    if (initial.f[i] == 0) {
      initial.f[i] = N2;
      initial.space = i;
    }
  }
  const ans = iterative_deepening(initial);
  console.log(ans.length);
}
main();
