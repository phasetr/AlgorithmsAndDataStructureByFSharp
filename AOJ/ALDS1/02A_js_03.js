// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/3590896/tonooo71/JavaScript
function bubbleSort(lgh, arr) {
  const flag = 1;
  const count = 0;
  while(flag) {
    flag = 0;
    for(let i = 0; i < lgh-1; i++) {
      if(Number(arr[i]) > Number(arr[i+1])) {
        [arr[i], arr[i+1]] = [arr[i+1], arr[i]];
        flag = 1;
        count++;
      }
    }
  }
  console.log(arr.join(" "));
  return count;
}
function Main(input) {
  const [a, b] = input.split("\n");
  console.log(bubbleSort(a, b.split(" ")));
}
Main(require("fs").readFileSync("/dev/stdin", "utf8"));
