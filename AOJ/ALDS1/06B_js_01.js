// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/2670736/enoyo/JavaScript
process.stdin.resume();
process.stdin.setEncoding('utf8');
let input = '';
process.stdin.on('data', function(chunk) {input += chunk;});
process.stdin.on('end', function() {main(input.split("\n"));});

function partition(A,p,r) {
  let x = A[r];
  let i = p - 1;
  let tmp;
  for (let j = p; j < r; j++) {
    if (A[j] <= x) {
      i++;
      tmp = A[i];
      A[i] = A[j];
      A[j] = tmp;
    }
  }
  i++;
  tmp = A[i];
  A[i] = A[r];
  A[r] = tmp;
  return i;
}

function main(lines){
  let n = Number(lines[0]);
  let A = lines[1].split(" ").map(Number);
  let target = partition(A,0,n-1);
  A[target] = `[${A[target]}]`;
  console.log(A.join(" "));
}
