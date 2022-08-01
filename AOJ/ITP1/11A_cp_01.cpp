// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_A/review/2168635/c7c7/C++
#include <iostream>
using namespace std;
int a[6];
string s;
void C(int i,int j,int k,int l){
  int t;t=a[i];a[i]=a[j];a[j]=a[k];a[k]=a[l];a[l]=t;
}
int main(){
  for(int i=0;i<6;i++)cin>>a[i];
  cin>>s;
  for(int i=0;i<s.size();i++){
    if(s[i]=='E'){for(int j=0;j<3;j++){C(0,2,5,3);}}
    if(s[i]=='W'){C(0,2,5,3);}
    if(s[i]=='S'){for(int j=0;j<3;j++){C(0,1,5,4);}}
    if(s[i]=='N'){C(0,1,5,4);}
  }
  cout<<a[0]<<endl;
}
