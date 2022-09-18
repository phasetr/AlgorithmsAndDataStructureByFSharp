// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/2529320/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux
const assert = require('assert');
line = require('fs').readFileSync(config.input, 'ascii').trim().split(config.newline);
n = Number(line.shift());
V = {};
w = {};
function add(obj, u, v, c) {
  if (!obj.hasOwnProperty(u)) obj[u] = {};
  obj[u][v] = c;
}
for (i in line) {
  ary = line[i].split(' ').map(Number);
  u = ary[0];
  V[u] = {'id': u, 'd': Number.POSITIVE_INFINITY,
          'pi': null, 'heapindex': null};
  for (j = 2; j < ary.length; j += 2)
    add(w, u, ary[j], ary[j+1]);
}
for (i in V) {
  if (V[i].id === 0) {
    V[i].d = 0;
    break;
  }
}

// heap tree

heap = new Array(n+1);
heapsize = 0;
for (i = 0; i <= n; i++) heap[i] = null; // heap stores node objects
function minHeapify(A, i) {
  var l, r, smallest, tmp;
  l = 2 * i;
  r = 2 * i + 1;
  if (l <= heapsize && A[l].d < A[i].d) smallest = l;
  else smallest = i;
  if (r <= heapsize && A[r].d < A[smallest].d) smallest = r;
  if (smallest !== i) {
    tmp = A[i];
    A[i] = A[smallest];
    A[i].heapindex = i;
    A[smallest] = tmp;
    A[smallest].heapindex = smallest;
    minHeapify(A, smallest);
  }
}
function heapExtractMin(A) {
  var min;
  assert(heapsize >= 1, 'heap underflow');
  min = A[1];
  min.heapindex = null;
  A[1] = A[heapsize];
  A[1].heapindex = 1;
  A[heapsize] = null;
  heapsize--;
  minHeapify(A, 1);
  return min;
}
function heapDecreaseKey(A, i, key) {
  var parent, tmp;
  assert(key.d <= A[i].d, 'new key is larger than current key');
  A[i] = key;
  A[i].heapindex = i;
  while (i > 1) {
    parent = Math.floor(i / 2);
    if (A[parent].d <= A[i].d) break;
    tmp = A[i];
    A[i] = A[parent];
    A[i].heapindex = i;
    A[parent] = tmp;
    A[parent].heapindex = parent;
    i = parent;
  }
}
const POSITIVE_INFINITY_NODE =
  {'id': null, 'd': Number.POSITIVE_INFINITY, 'pi': null, 'heapindex': null};
function minHeapInsert(A, key) {
  heapsize++;
  A[heapsize] = POSITIVE_INFINITY_NODE;
  heapDecreaseKey(A, heapsize, key);
}

// Dijkstra algorithm

function relax(u, v, w) {
  if (v.d > u.d + w[u.id][v.id]) {
    v.d = u.d + w[u.id][v.id];
    v.pi = u;
    if (v.heapindex !== null) heapDecreaseKey(heap, v.heapindex, v);
  }
}

function dijkstra(w) {
  var S = [], i, Q = heap, u;
  for (i in V) minHeapInsert(Q, V[i]);
  while (heapsize !== 0) {
    u = heapExtractMin(Q);
    S.push(u);
    for (j in w[u.id]) {
      v = V[j];
      relax(u, v, w);
    }
  }
}

dijkstra(w);
for (i in V) console.log("%s %d", i, V[i].d);
