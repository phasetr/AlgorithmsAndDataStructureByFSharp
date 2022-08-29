#include <iostream> // cout, endl, cin
#include <vector> // vector
// #include <bits/stdc++.h>
using namespace std;
int main(){
    int n;
    cin >> n;
    vector<int> A(n);
    for (int i = 0; i < n; i++){ cin >> A[i]; }
    vector<int> C(10001, 0);
    for (int i = 0; i < n; i++){ C[A[i]]++; }
    int v = 0;
    for (int i = 0; i < n; i++){
        while (C[v] == 0){ v++; }
        cout << v;
        C[v]--;
        if (i < n - 1){ cout << ' '; }
    }
    cout << endl;
}
