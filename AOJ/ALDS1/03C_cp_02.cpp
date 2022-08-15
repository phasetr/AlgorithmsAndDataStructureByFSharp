// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/4261448/SSRS/C++
#include <iostream>
#include <list>
using namespace std;
int main(){
  cin.tie(0);
  int n;
  cin >> n;
  list<int> L;
  for (int i = 0; i < n; i++){
    string q;
    cin >> q;
    if (q == "insert"){
      int x;
      cin >> x;
      L.push_front(x);
    }
    if (q == "delete"){
      int x;
      cin >> x;
      for (list<int>::iterator itr = L.begin(); itr != L.end(); itr++){
        if (*itr == x){
          L.erase(itr);
          break;
        }
      }
    }
    if (q == "deleteFirst"){
      L.pop_front();
    }
    if (q == "deleteLast"){
      L.pop_back();
    }
  }
  while (!L.empty()){
    cout << L.front();
    L.pop_front();
    if (!L.empty()){
      cout << ' ';
    }
  }
  cout << endl;
}
