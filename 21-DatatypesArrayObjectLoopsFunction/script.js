function removeDuplicatesAndCount(arr) {
    let uniqueArr = [...new Set(arr)];
    
    let duplicateCount = arr.length - uniqueArr.length;
    
    return {
        newArray: uniqueArr,
        duplicateCount: duplicateCount
    };
}

 

function isPalindrome(word) { 
    let cleaned = word.toLowerCase().replace(/[^a-z0-9]/g, '');
     
    let reversed = cleaned.split('').reverse().join('');
     
    return cleaned === reversed;
}

 

function countSmallerElements(arr, num) {
    let count = 0;
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] < num) {
            count++;
        }
    }
    return count;
}
 


function checkAbundantOrDeficient(num) {
    if (num <= 0) return "Müsbət ədəd daxil edin";
    
    let sumOfDivisors = 0;
     
    for (let i = 1; i < num; i++) {
        if (num % i === 0) {
            sumOfDivisors += i;
        }
    }
    
    if (sumOfDivisors > num) {
        return `${num} Abundant ədəddir (Bölənlər cəmi: ${sumOfDivisors})`;
    } else {
        return `${num} Deficient ədəddir (Bölənlər cəmi: ${sumOfDivisors})`;
    }
}
 


function squareArrayElements(arr) { 
    return arr.map(element => element * element);
}
 
function squareArrayManually(arr) {
    let newArr = [];
    for (let i = 0; i < arr.length; i++) {
        newArr.push(arr[i] * arr[i]);
    }
    return newArr;
}
 
console.log("\n========== TEST NƏTİCƏLƏRİ ==========\n");
 
console.log("1. Tekrarlanan silmək:");
let testArr = [1, 2, 2, 3, 4, 4, 5];
let res = removeDuplicatesAndCount(testArr);
console.log("Array:", testArr);
console.log("Təmizlənmiş:", res.newArray);
console.log("Təkrarlanan sayı:", res.duplicateCount);
 
console.log("\n2. Polindrom testləri:");
console.log("'level' polindromdur?", isPalindrome("level"));
console.log("'hello' polindromdur?", isPalindrome("hello"));
 
console.log("\n3. Kiçik element sayı:");
console.log("[10, 20, 5, 8, 15] arrayində 10-dan kiçiklər:", countSmallerElements([10, 20, 5, 8, 15], 10));
 
console.log("\n4. Abundant/Deficient testləri:");
console.log(checkAbundantOrDeficient(12));
console.log(checkAbundantOrDeficient(13));
 
console.log("\n5. Kvadrata yüksəltmək:");
console.log("[1, 2, 3, 4, 5] ->", squareArrayElements([1, 2, 3, 4, 5]));