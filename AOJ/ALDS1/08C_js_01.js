// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_C/review/2689303/enoyo/JavaScript
process.stdin.resume();
process.stdin.setEncoding("utf8");
let input = "";
process.stdin.on("data", function(chunk) {input += chunk;});
process.stdin.on("end", function() {main(input.split("\n"));});

function allocNode(key) {
  const p = {};
  p.key = key;
  p.parent = null;
  p.left = null;
  p.right = null;
  return p;
}

function insert(p,c) {
  if (p === null) return c;
  if (c.key < p.key) {
    p.left = insert(p.left,c);
    p.left.parent = p;
  }  else {
    p.right = insert(p.right,c);
    p.right.parent = p;
  }
  return p;
}

function find(p,key) {
  if (p !== null && p.key !== key) {
    if (key < p.key) p = find(p.left,key);
    else p = find(p.right,key);
  }
  return p;
}

function remove(root,key) {
  let next;
  const p = find(root,key);
  if (p === null) return;
  const pp = p.parent;
  if (p.right === null) next = p.left;
  else {
    next = p.right;
    if (p.left !== null) {
      while (next.left !== null) next = next.left;
      if (next.parent !== p) {
        next.parent.left = next.right;
        next.right = p.right;
      }
      next.left = p.left;
    }
  }
  if (pp !== null) {
    if (pp.left === p) pp.left = next;
    else pp.right = next;
  } else root = next;
  if (next !== null) next.parent = pp;
}

function inset(p,ary) {
  if (p === null) return;
  inset(p.left,ary);
  ary.push(p.key);
  inset(p.right,ary);
}

function preset(p,ary) {
  if (p === null) return;
  ary.push(p.key);
  preset(p.left,ary);
  preset(p.right,ary);
}

function dump(p,setfunc) {
  const ary = [];
  setfunc(p,ary);
  console.log(ary.map(x => ` ${x}`).join(""));
}


function main(lines){
  const n = Number(lines[0]);
  let p, key, line, root = null;

  for (let i = 0; i < n; i++) {
    line = lines[i+1].split(" ");
    switch(line[0][0]) {
    case "i":
      key = Number(line[1]);
      p = allocNode(key);
      root = insert(root,p);
      break;
    case "p":
      dump(root,inset);
      dump(root,preset);
      break;
    case "f":
      key = Number(line[1]);
      if (find(root,key) !== null) console.log("yes");
      else console.log("no");
      break;
    case "d":
      key = Number(line[1]);
      remove(root,key);
      break;
    }
  }
}
