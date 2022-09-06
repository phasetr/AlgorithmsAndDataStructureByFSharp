// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/2402243/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

line = require('fs').readFileSync(config.input, 'ascii')
  .split(config.newline, 3);

preorder = line[1].split(' ');
inorder = line[2].split(' ');

tree = {};

function decode(preorder, inorder) {
  var id, idx_in, in_left, in_right, pre_left, pre_right, left, right;
  id = preorder[0];
  idx_in = inorder.indexOf(id);
  in_left = inorder.slice(0, idx_in + 1);
  in_right = inorder.slice(idx_in + 1);
  pre_left = preorder.slice(1, idx_in + 1);
  pre_right = preorder.slice(idx_in + 1);
  if (pre_left.length === 0) left = null;
  else left = decode(pre_left, in_left);
  if (pre_right.length === 0) right = null;
  else right = decode(pre_right, in_right);
  tree[id] = {'left': left, 'right': right};
  return id;
}

decode(preorder, inorder);
root_id = preorder[0];
function postorder(id) {
  const node = tree[id], res = [];
  if (node.left !== null) res = res.concat(postorder(node.left));
  if (node.right !== null) res = res.concat(postorder(node.right));
  res.push(id);
  return res;
}
console.log(postorder(root_id).join(' '));
