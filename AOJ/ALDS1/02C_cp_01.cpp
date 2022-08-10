// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_C/review/749615/ei1333/C++
#include<iostream>
#include<algorithm>
#include<vector>
using namespace std;
int main(){
  int n,mini;
  cin >> n;
  vector <string> data1(n),data2(n);
  for(int i=0;i<n;i++){
    cin >> data1[i];
    data2[i] = data1[i];
  }
  for(int i=0;i<n-1;i++){
    for(int j=n-1;j>i;j--){
      if(data1[j][1]<data1[j-1][1]) {swap(data1[j],data1[j-1]);}
    }
  }
  for(int i=0;i<n;i++){
    mini = i;
    for(int j=i;j<n;j++){
      if(data2[j][1]<data2[mini][1]) mini = j;
    }
    if(mini != i) swap(data2[i],data2[mini]);
  }
  for(int i=0;i<n;i++) cout << (i!=0?" ":"") << data1[i];
  cout << endl << "Stable" << endl;
  for(int i=0;i<n;i++) cout << (i!=0?" ":"") << data2[i];
  if(data1==data2) cout << endl << "Stable" << endl;
  else cout << endl << "Not stable" << endl;
}
