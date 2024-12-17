//*****************************************************************************
//** 2182. Construct String With Repeat Limit                       leetcode **
//*****************************************************************************

char* repeatLimitedString(char* s, int repeatLimit) {
    int cnt[26] = {0};
    int n = strlen(s);

    for (int i = 0; i < n; i++) {
        cnt[s[i] - 'a']++;
    }

    // Allocate memory for the result string
    char* ans = (char*)malloc((n + 1) * sizeof(char));
    int ansIndex = 0;

    for (int i = 25, j = 24; i >= 0; i--) {
        j = (j < i - 1) ? j : i - 1;

        while (1) {
            for (int k = (cnt[i] < repeatLimit ? cnt[i] : repeatLimit); k > 0; k--) {
                ans[ansIndex++] = 'a' + i;
                cnt[i]--;
            }

            if (cnt[i] == 0) {
                break;
            }

            while (j >= 0 && cnt[j] == 0) {
                j--;
            }

            if (j < 0) {
                break;
            }

            ans[ansIndex++] = 'a' + j;
            cnt[j]--;
        }
    }

    ans[ansIndex] = '\0';
    return ans;
}