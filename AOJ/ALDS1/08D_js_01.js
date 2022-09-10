// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_D/review/5284133/anndonut/JavaScript
let lines = require('fs').readFileSync(0).toString().split('\n');
lines = lines.map((line) => line.split(/ /));

function rightRotate(t) {
  let s = t.left;
  t.left = s.right;
  s.right = t;
  return s;
}

function leftRotate(t) {
  let s = t.right;
  t.right = s.left;
  s.left = t;
  return s;
}

function insert(t, key, priority) {
  if (t == null) {
    return { left: null, right: null, key: key, priority: priority };
  }
  if (key == t.key) {
    return t;
  }
  if (key < t.key) {
    t.left = insert(t.left, key, priority);
    if (t.priority < t.left.priority)
      t = rightRotate(t);
  } else {
    t.right = insert(t.right, key, priority);
    if (t.priority < t.right.priority)
      t = leftRotate(t);
  }
  return t;
}

function deleteNode(t, key) {
  if (t == null) {
    return null;
  }
  if (key < t.key) {
    t.left = deleteNode(t.left, key);
  } else if (key > t.key) {
    t.right = deleteNode(t.right, key);
  } else {
    return _deleteNode(t, key);
  }
  return t;
}

function _deleteNode(t, key) {
  if (t.left == null && t.right == null) {
    return null;
  } else if (t.left == null) {
    t = leftRotate(t);
  } else if (t.right == null) {
    t = rightRotate(t);
  } else {
    if (t.left.priority > t.right.priority) {
      t = rightRotate(t);
    } else {
      t = leftRotate(t);
    }
  }
  return deleteNode(t, key);
}

function find(t, key) {
  while (t != null) {
    let tkey = t.key;
    if (key < tkey) t = t.left;
    else if (key > tkey) t = t.right;
    else break;
  }
  return t;
}

function printInorder(t) {
  if (t == null) return "";
  return printInorder(t.left) + " " + String(t.key) + printInorder(t.right);
}

function printPreorder(t) {
  if (t == null) return "";
  return " " + String(t.key) + printPreorder(t.left) + printPreorder(t.right);
}

function printDebug(t, level) {
  let indent = "";
  if (level == 0) console.log("DEBUG: START PRINT-TREE");
  for (let i = 0; i < level; ++i) indent = indent + " ";
  if (t == null) {
    console.log( indent + "NIL");
  } else {
    console.log(indent + "key=" + Number(t.key) + ", priority=" + Number(t.priority));
    printDebug(t.left, level + 1);
    printDebug(t.right, level + 1);
  }
  if (level == 0) console.log("DEBUG: FINISH PRINT-TREE");
}

let n = lines[0];
let root = null;
for (let i = 1; i <= n; ++i) {
  //printDebug(root, 0);
  let line = lines[i];
  if (line[0] == 'insert') {
    root = insert(root, Number(line[1]), Number(line[2]));
  } else if (line[0] == 'find') {
    if (find(root, Number(line[1])) != null)
      console.log("yes");
    else
      console.log("no");
  } else if (line[0] == 'delete') {
    root = deleteNode(root, Number(line[1]));
  } else if (line[0] == 'print') {
    console.log(printInorder(root));
    console.log(printPreorder(root));
  } else if (line[0] == 'reset') { // for debug
    console.log("RESET " + line[1]);
    root = null;
  }
}
//printDebug(root, 0);
