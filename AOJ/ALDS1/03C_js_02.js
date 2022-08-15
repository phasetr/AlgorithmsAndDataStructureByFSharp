// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/4738830/tyahha/JavaScript
process.stdin.resume();
process.stdin.setEncoding("utf8");

const reader = require("readline").createInterface({
  input: process.stdin,
  output: process.stdout,
});

const lines = [];

reader.on("line", (line) => {
  lines.push(line);
});

const nil = {};
nil.after = nil;
nil.before = nil;

reader.on("close", () => {
  const n = lines[0] - 0;
  for (let i = 1; i <= n; i++) {
    let [command, operand] = lines[i].split(" ");
    switch (command) {
      case "insert":
        const o = {
          value: operand,
          before: nil,
          after: nil.after,
        };
        nil.after.before = o;
        nil.after = o;
        break;
      case "delete":
        for (let c = nil.after; nil !== c; c = c.after) {
          if (c.value === operand) {
            c.before.after = c.after;
            c.after.before = c.before;
            break;
          }
        }
        break;
      case "deleteFirst":
        nil.after = nil.after.after;
        nil.after.before = nil;
        break;
      case "deleteLast":
        nil.before = nil.before.before;
        nil.before.after = nil;
        break;
    }
  }

  let first = true;
  for (let c = nil.after; nil !== c; c = c.after) {
    if (!first) process.stdout.write(" ");
    process.stdout.write(c.value);
    first = false;
  }
  console.log("");
});
