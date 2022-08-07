// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_D/review/3590858/tonooo71/JavaScript
function Main(input) {
  input = input.split("\n");
  const money = - Infinity;
  const tmp = input[input[0]];
  for(let i = input[0]-1; i > 0; i--) {
    money = Math.max(money, tmp - Number(input[i]));
    tmp = Math.max(tmp, Number(input[i]));
  }
  console.log(money);
}
Main(require("fs").readFileSync("/dev/stdin", "utf8"));
