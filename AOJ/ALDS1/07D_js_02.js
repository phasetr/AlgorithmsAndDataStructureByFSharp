// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/6217788/dorage/JavaScript
const { off } = require('process');
const readline = require('readline');

let input = [];

readline
  .createInterface({
    input: process.stdin,
    output: process.stdout,
  })
  .on('line', function (line) {
    input.push(line);
  })
  .on('close', function () {
    solution(input);
    process.exit();
  });

function solution(input) {
  const n = Number(input.shift());
  const preorder = input.shift().split(' ').map(Number);
  const inorder = input.shift().split(' ').map(Number);

  console.log(reconstructor(preorder, inorder).join(' '));
}

function reconstructor(preorder, inorder) {
  if (!preorder.length) return [];
  const mid = preorder[0];
  const midIdx = inorder.findIndex((e) => e === mid);

  const L = reconstructor(
    preorder.slice(1, midIdx + 1),
    inorder.slice(0, midIdx)
  );
  const R = reconstructor(
    preorder.slice(midIdx + 1, preorder.length),
    inorder.slice(midIdx + 1, inorder.length)
  );

  return [...L, ...R, mid];
}
