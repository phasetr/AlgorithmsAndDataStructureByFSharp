// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/6648676/d_yama/JavaScript
"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
  if (k2 === undefined) k2 = k;
  var desc = Object.getOwnPropertyDescriptor(m, k);
  if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
    desc = { enumerable: true, get: function() { return m[k]; } };
  }
  Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
  if (k2 === undefined) k2 = k;
  o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
  Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
  o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
  if (mod && mod.__esModule) return mod;
  var result = {};
  if (mod != null) for (var k in mod) if (k !== "default" && Object.prototype.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
  __setModuleDefault(result, mod);
  return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
const fs = __importStar(require("fs"));
const str = fs.readFileSync('/dev/stdin', 'utf8');
const inputs = str.trim().split('\n');
const count = Number(inputs.shift());
const tree = [...Array(count)].map(_ => ({}));
inputs.forEach(input => {
  const [id, left, right] = input.split(' ').map(Number);
  const node = tree[id];
  if (left !== -1) {
    node.leftIndex = left;
    tree[left].parentIndex = id;
  }
  if (right !== -1) {
    node.rightIndex = right;
    tree[right].parentIndex = id;
  }
});
const getDepth = (index) => {
  let idx = index;
  let depth = 0;
  while (tree[idx].parentIndex !== undefined) {
    idx = tree[idx].parentIndex;
    depth++;
  }
  return depth;
};
const getSibling = (index) => {
  var _a, _b;
  const node = tree[index];
  if (node.parentIndex === undefined) {
    return -1;
  }
  return tree[node.parentIndex].leftIndex === index
    ? (_a = tree[node.parentIndex].rightIndex) !== null && _a !== void 0 ? _a : -1
  : (_b = tree[node.parentIndex].leftIndex) !== null && _b !== void 0 ? _b : -1;
};
const getDegree = (index) => {
  const node = tree[index];
  let degree = 0;
  if (node.rightIndex !== undefined) {
    degree++;
  }
  if (node.leftIndex !== undefined) {
    degree++;
  }
  return degree;
};
const getHeight = (index) => {
  let leftHeight = 0;
  let rightHeight = 0;
  const node = tree[index];
  if (node.leftIndex !== undefined) {
    leftHeight = getHeight(node.leftIndex) + 1;
  }
  if (node.rightIndex !== undefined) {
    rightHeight = getHeight(node.rightIndex) + 1;
  }
  return Math.max(leftHeight, rightHeight);
};
const getType = (index) => {
  const node = tree[index];
  if (node.parentIndex === undefined) {
    return 'root';
  }
  if (node.leftIndex === undefined && node.rightIndex === undefined) {
    return 'leaf';
  }
  return 'internal node';
};
const printNode = (index) => {
  var _a;
  const node = tree[index];
  console.log(`node ${index}: parent = ${(_a = node.parentIndex) !== null && _a !== void 0 ? _a : -1}, sibling = ${getSibling(index)}, degree = ${getDegree(index)}, depth = ${getDepth(index)}, height = ${getHeight(index)}, ${getType(index)}`);
};
tree.forEach((_, index) => {
  printNode(index);
});
