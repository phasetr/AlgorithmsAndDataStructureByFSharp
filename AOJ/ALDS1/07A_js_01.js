// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/2402105/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
const config = { input: '/dev/stdin', newline: '\n' }; // linux
const line = require('fs').readFileSync(config.input, 'ascii')
  .trim()
  .split(config.newline);
line.shift();

const tree = {};

function make_node(n) {
  if (tree.hasOwnProperty(n)) {return tree[n];}
  const node = {'parent': -1, 'depth': null, 'type': null, 'children': null};
  tree[n] = node;
  return node;
}

for (i in line) {
  const ary = line[i].split(' ');
  const node_id = ary.shift();
  const node = make_node(node_id);
  ary.shift();
  node.children = ary;
  if (ary.length === 0) {node.type = 'leaf';}
  else {node.type = 'internal node';}
  for (j in ary) {
    child = make_node(ary[j]);
    child.parent = node_id;
  }
}

for (i in tree) {if (tree[i].parent === -1) {root_id = i;}}
let root = tree[root_id];
root.type = 'root';

function set_depth(node, depth) {
  const  children;
  node.depth = depth;
  children = node.children;
  for (i in children) {set_depth(tree[children[i]], depth + 1);}
}

set_depth(root, 0);
const keys = Object.keys(tree).sort(function (a, b) { return a - b; });

for (i in keys) {
  console.log('node %s: parent = %s, depth = %d, %s, [%s]',
              i, tree[i].parent, tree[i].depth, tree[i].type,
              tree[i].children.join(', '));
}
