// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/3557571/musou1500/JavaScript
let content = '';
process.stdin.resume();
process.stdin.setEncoding('utf8');
process.stdin.on('data', buf => {
  content += buf;
});

let numComp = 0;
process.stdin.on('end', () => {
  const [nums] = content
        .trim()
        .split('\n')
        .slice(1)
        .map(nums => nums.split(' ').map(n => +n));
  mergeSort(nums, 0, nums.length);
  console.log(numComp);
});

// merge in-place
const merge = (nums, left, mid, right) => {
  const l = nums.slice(left, mid);
  const r = nums.slice(mid, right);
  l.push(Infinity);
  r.push(Infinity);
  let i = j = 0;
  for (let k = left; k < right; k++) {
    if (l[i] < r[j]) {
      nums[k] = l[i++];
    } else {
      nums[k] = r[j++];
      numComp += l.length - 1 - i;
    }
  }
};

const mergeSort = (nums, left, right) => {
  if (left + 1 < right) {
    const mid = Math.floor((left + right) / 2);
    mergeSort(nums, left, mid);
    mergeSort(nums, mid, right);
    merge(nums, left, mid, right);
  }
};
