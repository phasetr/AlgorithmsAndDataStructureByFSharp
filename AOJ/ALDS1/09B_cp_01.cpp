// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/6881463/vjudge2/C++
#include <iostream>
using namespace std;
const int MAXN=500000+10;
int num[MAXN];
int H;

void f(int n){
  int largest=n;
  int l=n*2;
  int r=n*2+1;
  if (l<=H && num[l]>num[largest]) largest=l;
  if (r<=H && num[r]>num[largest]) largest=r;
  if (largest!=n) {
    swap(num[n],num[largest]);
    f(largest);
  }
}

int main(){
  cin>>H;
  for (int i=1;i<=H;i++) cin>>num[i];
  for (int i=(H+1)/2;i>0;i--) f(i);
  for (int i=1;i<=H;i++) cout<<' '<<num[i];
  cout<<endl;
  return 0;
}
