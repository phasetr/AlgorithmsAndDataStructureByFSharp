// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/6229496/sara3wati_3333/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = (input.trim()).split("\n");

function makeNode (key) {
  const node = {};
  node.key = key;
  node.left = null;
  node.right = null;
  return node;
}

function insert (former, node) {
  if (former === null) return node;
  if (former.key > node.key) {
    former.left = insert(former.left, node);
  } else {
    former.right = insert(former.right, node);
  }
  return former;
}

function inOrder (node, arr) {
  if (node === null) return;
  inOrder(node.left, arr);
  arr.push(node.key);
  inOrder(node.right, arr);
}

function preOrder (node, arr) {
  if (node === null) return;
  arr.push(node.key);
  preOrder(node.left, arr);
  preOrder(node.right, arr);
}

function print (node, func) {
  const ary = [];
  func(node,ary);
  console.log(ary.map(n => ` ${n}`).join(""));
}

const n = parseInt(lines[0], 10);
let root = null;
for (let i = 1; i <= n; i++) {
  const line = lines[i].split(" ");
  if (line[0] === "insert") {
    const key = parseInt(line[1], 10);
    const node = makeNode(key);
    root = insert(root, node);    
  } else if (line[0] === "print") {
    print(root, inOrder);
    print(root, preOrder);
  }
}
