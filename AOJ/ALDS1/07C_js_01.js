// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_C/review/2402180/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

line = require('fs').readFileSync(config.input, 'ascii')
  .trim()
  .split(config.newline);

line.shift();

tree = {};
for (const i in line) {
  ary = line[i].split(' ');
  tree[ary[0]] = {'left': ary[1], 'right': ary[2], 'root': true};
}

for (const i in tree) {
  if (tree[i].left !== '-1') tree[tree[i].left].root = false;
  if (tree[i].right !== '-1') tree[tree[i].right].root = false;
}
for (const i in tree) {
  if (tree[i].root) root_id = i;
}

function preorder(id) {
  const node = tree[id], left = node.left, right = node.right, res = [id];
  if (left !== '-1') res = res.concat(preorder(left));
  if (right !== '-1') res = res.concat(preorder(right));
  return res;
}

console.log('Preorder');
console.log(' ' + preorder(root_id).join(' '));

function inorder(id) {
  const node = tree[id], left = node.left, right = node.right, res = [];
  if (left !== '-1') res = res.concat(inorder(left));
  res.push(id);
  if (right !== '-1') res = res.concat(inorder(right));
  return res;
}

console.log('Inorder');
console.log(' ' + inorder(root_id).join(' '));

function postorder(id) {
  const node = tree[id], left = node.left, right = node.right, res = [];
  if (left !== '-1') res = res.concat(postorder(left));
  if (right !== '-1') res = res.concat(postorder(right));
  res.push(id);
  return res;
}

console.log('Postorder');
console.log(' ' + postorder(root_id).join(' '));
