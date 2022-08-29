// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_A/review/6274033/eraser5th/JavaScript
const countingSort = (A) => {
  let C = new Array(2000000 + 1).fill(0);
  A.forEach((a) => C[a]++);
  C.reduce((a, b, i, c) => c[i] = a + b);
  let B = [];
  A.forEach((a) => {
    B[C[a]-1] = a;
    C[a]--;
  });
  return B;
};

function main(input) {
  console.log(countingSort(input.split('\n')[1].split(' ').map(n=>parseInt(n))).join(' '));
}

let fd = "";
process.stdin.resume().on("data",c=>fd+=c).on("end",()=>main(fd));
