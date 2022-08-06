// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_C/review/1732109/s1230149/C++
#include <iostream>
using namespace std;

int main(){
  int n,ans=0;
  cin>>n;
  while(n--){
    int a;
    cin>>a;
    int i=2;
    while(i*i<=a && a%i){i++;}
    if(a%i||a==2){ans++;}
  }
  cout<<ans<<endl;
}
