// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_B/review/2692319/enoyo/JavaScript
process.stdin.resume();
process.stdin.setEncoding("utf8");
let input = "";
process.stdin.on("data", function(chunk) {input += chunk;});
process.stdin.on("end", function() {main(input.split("\n"));});

function allocNode(key) {
  const p = {};
  p.key = key;
  p.left = null;
  p.right = null;
  return p;
}

function insert(p,c) {
  if (p === null) return c;
  if (c.key < p.key) {
    p.left = insert(p.left,c);
  }  else {
    p.right = insert(p.right,c);
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
    }
  }
}
