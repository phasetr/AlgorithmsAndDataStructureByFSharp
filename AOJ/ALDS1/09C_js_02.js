// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/2499287/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

s = require('fs').createReadStream(config.input, {encoding: 'ascii'});
rl = require('readline').createInterface({input: s, output: process.stdout});
rl.on('line', onRead);
rl.on('end', function () { s.close(); });

const MAXSIZE = 2000000;
const MIN = -1;
h/*eap*/ = new Array(MAXSIZE+1);
s/*ize*/ = 0;
for (i = 0; i <= MAXSIZE; i++) h[i] = MIN;

function maxHeapify(A, i) {
  let l, r, largest, tmp;
  l = i * 2;
  r = i * 2 + 1;
  if (l <= s && A[l] > A[i]) largest = l;
  else largest = i;
  if (r <= s && A[r] > A[largest])
    largest = r;
  if (largest !== i) {
    tmp = A[largest];
    A[largest] = A[i];
    A[i] = tmp;
    maxHeapify(A, largest);
  }
}

function heapExtractMax(A) {
  let max;
  if (s < 1) {
    console.error("???????????¢??????????????????");
    process.exit();
  }
  max = A[1];
  A[1] = A[s];
  s--;
  maxHeapify(A, 1);
  return max;
}

function heapIncreaseKey(A, i, key) {
  let parent, tmp;
  if (key < A[i]) {
    console.error("??°????????????????????¨????????????????°???????");
    process.exit(1);
  }
  A[i] = key;
  while (i > 1) {
    parent = Math.floor(i / 2);
    if (A[parent] >= A[i]) return;
    tmp = A[parent];
    A[parent] = A[i];
    A[i] = tmp;
    i = parent;
  }
}

function maxHeapInsert(A, key) {
  s++;
  A[s] = MIN;
  heapIncreaseKey(A, s, key);
}

function print() {
  console.log(h.slice(1, s + 1));
}

function onRead(line) {
  if (line === 'end') {
    rl.close();
  } else if (line === 'extract') {
    console.log(heapExtractMax(h));
  } else {
    maxHeapInsert(h, parseInt(line.split(' ')[1]));
  }
}
