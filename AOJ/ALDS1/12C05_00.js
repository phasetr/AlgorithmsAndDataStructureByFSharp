// https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_12_C
function solve(n,lines){
  const V = {};
  function add(obj, u, v, c) {
    if (!obj.hasOwnProperty(u)) { obj[u] = {}; }
    obj[u][v] = c;
  }
  for (const line of lines) {
    const xs = line.split(' ').map(Number);
    const u = xs[0];
    V[u] = {
      'id': u,
      'd': Number.POSITIVE_INFINITY,
      'pi': null,
      'heapindex': null};
    for (let j=2; j<xs.length; j+=2) { add(w, u, xs[j], xs[j+1]); }
  }
  for (const i in V) {
    if (V[i].id === 0) {
      V[i].d = 0;
      break;
    }
  }

  // heap tree
  const heap = Array.from(Array(n+1), () => null);
  let heapsize = 0;
  function minHeapify(A, i) {
    let smallest = 0;
    const l = 2*i;
    const r = 2*i+1;
    smallest = (l <= heapsize && A[l].d < A[i].d) ? l : i;
    smallest = (r <= heapsize && A[r].d < A[smallest].d) ? r : smallest;
    if (smallest !== i) {
      const tmp = A[i];
      A[i] = A[smallest];
      A[i].heapindex = i;
      A[smallest] = tmp;
      A[smallest].heapindex = smallest;
      minHeapify(A, smallest);
    }
  }
  function heapExtractMin(A) {
    const min = A[1];
    min.heapindex = null;
    A[1] = A[heapsize];
    A[1].heapindex = 1;
    A[heapsize] = null;
    heapsize--;
    minHeapify(A, 1);
    return min;
  }
  function heapDecreaseKey(A, i, key) {
    A[i] = key;
    A[i].heapindex = i;
    while (i > 1) {
      const parent = Math.floor(i / 2);
      if (A[parent].d <= A[i].d) { break; }
      const tmp = A[i];
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
    const S = [];
    const Q = heap;
    for (const i in V) minHeapInsert(Q, V[i]);
    while (heapsize !== 0) {
      const u = heapExtractMin(Q);
      S.push(u);
      for (j in w[u.id]) {
        const v = V[j];
        relax(u, v, w);
      }
    }
  }
  const w = {};
  dijkstra(w);
  return V;
}
const lines = require('fs').readFileSync("/dev/stdin", 'ascii').trim().split("\n");
const n = Number(lines.shift());
const V = solve(n,lines);
for (k in V) { console.log(`${k} ${V[k].d}`); }

function compare(xa,ya) { return JSON.stringify(xa) === JSON.stringify(ya); }
{
  const V = solve(5,["0 3 2 3 3 1 1 2","1 2 0 2 3 4","2 3 0 3 3 1 4 1","3 4 2 1 0 1 1 4 4 3","4 2 2 1 3 3"]);
  const xs = [];
  for (k in V) { xs.push(`${k} ${V[k].d}`); };
  console.log(xs);
  console.log(compare(xs,["0 0","1 2","2 2","3 1","4 3"]));
}
