// https://atcoder.jp/contests/dp/submissions/31892153
#include <cstdio>
#include <vector>
using namespace std;
long long dp[100005],es[100005],ans[100005],m;
int n;
vector<int>v[100005];
long long dfs(int x,int p){
    dp[x]=1;
    for(int i=0;i<v[x].size();++i){
        if(v[x][i]==p)continue;
        dp[x]=(dp[x]*(dfs(v[x][i],x)+1))%m;
    }
    long long tms=1;
    for(int i=0;i<v[x].size();++i){
        if(v[x][i]==p)continue;
        es[v[x][i]]=tms;
        tms=(tms*(dp[v[x][i]]+1))%m;
    }
    tms=1;
    for(int i=v[x].size()-1;i>=0;--i){
        if(v[x][i]==p)continue;
        es[v[x][i]]=(es[v[x][i]]*tms)%m;
        tms=(tms*(dp[v[x][i]]+1))%m;
    }
    return dp[x];
}
void go(int x,int p,long long up){
    ans[x]=(dp[x]*(up+1))%m;
    for(int i=0;i<v[x].size();++i){
        if(v[x][i]==p)continue;
        go(v[x][i],x,(es[v[x][i]]*(up+1))%m);
    }
}
int main(){
    scanf("%d%lld",&n,&m);
    for(int i=1;i<n;++i){
        int x,y;
        scanf("%d%d",&x,&y);
        v[x].push_back(y);
        v[y].push_back(x);
    }
    dfs(1,-1);
    go(1,-1,0);
    for(int i=1;i<=n;++i)printf("%lld\n",ans[i]);
    return 0;
}
