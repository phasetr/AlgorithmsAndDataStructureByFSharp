// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/6422854/enantiomorph/JavaScript
const [n, inputArr] = require(`fs`).readFileSync(`/dev/stdin`, `utf8`).split(`\n`);
const arr = inputArr.split(` `).map(Number);
const swap = 0;
for (let i=0; i<+n; i++) {
  const minIndex = i;
  for (let j=i; j<+n; j++) {
    if (arr[minIndex] > arr[j]) {minIndex = j;}
  }
  if (minIndex > i) {
    [arr[i], arr[minIndex]] = [arr[minIndex], arr[i]];
    swap++;
  }
}
console.log(`${arr.join(` `)}\n${swap}`);
