
let selectTrait = document.querySelector("#select-trait");
let entryForm = document.querySelector("#entry-form");
let inputContainer = document.querySelector("#input-container");
let numCal = document.querySelector("#num-cal");
let idArr;
let ratioArr;
let targetNFT;
let numTrait;
var targetExistCal = []; 

//Select Value 
selectTrait.addEventListener('change', (e)=> {
    console.log(e.target.value);
    numTrait = e.target.value;
    SetInput(e.target.value);
})
entryForm.addEventListener("submit", (e) => {
    e.preventDefault();
    numCal.innerHTML = "Calculating...";
    targetNFT = document.querySelector("#target-nft").value;
    let inputIDEls = e.target.querySelectorAll(".input-id");
    let inputRatioEls = e.target.querySelectorAll(".input-ratio");
    idArr = [];
    for (let i =0; i<inputIDEls.length; i++) {
        let rs1 = inputIDEls[i].value.split("-");
        let rs2 = [];
        for(let i =0; i< rs1.length; i++) {
            rs2.push(parseInt(rs1[i]))
        }
        idArr.push(rs2);
    }
    ratioArr = [];
    for (let i =0; i<inputRatioEls.length; i++) {
        let rs1 = inputRatioEls[i].value.split("-");
        let rs2 = [];
        for(let i =0; i< rs1.length; i++) {
            rs2.push(parseInt(rs1[i]))
        }
        ratioArr.push(rs2);
    }
    targetExistCal = TargetExistCalculate(ratioArr);
    console.log(targetExistCal);
    //  let arr =  Combinaion2(...idArr);
     
    let res1 = Combinaions(...idArr);
    
    let sumf = Filter(res1);

    console.log(res1);
    console.log(sumf);
    // let res2 = Get(arr);
     CreateDownloadLink(sumf);
    
})

const Filter = (arr) => {
    let rs = [];
    for( let i = arr.length -1; i >= 0 ; i--) {
            if(Validator(arr[i],rs)) { 
                rs.push(arr[i]);
            }
    }

    return rs;
} 

const CheckES = (arr1, arr2) => {
    for(let i = 0; i< arr2.length; i++) {
        let arr2temp = arr2[i].toString();
        if(arr2temp === arr1.toString()) return true; 
    }
    return false;
}

const TargetExistCalculate = (ratioArr) => {
    let result = [];
    for(let i = 0; i< ratioArr.length ; i++) {
        let arrTemp = [];
        arrTemp = PercentageCal(ratioArr[i], targetNFT);
        result.push(arrTemp);
    }
    return result;
}

const CreateDownloadLink = (arr) => {
    numCal.innerHTML = "Done!!";
    let csvContent = "data:text/csv;charset=utf-8,";
    arr.forEach(function (rowArray) {
        let row = rowArray.join(",");
        csvContent += row + "\r\n";
    });

    let encodedUri = encodeURI(csvContent);
    let link = document.createElement("a");
    link.setAttribute("href", encodedUri);
    link.setAttribute("download", "4ndrvGen.csv");
    link.innerHTML = "Download CSV";
    document.body.appendChild(link);
}



// Set Input Value
const SetInput = (e) => {
    inputContainer.innerHTML = "";
    for( let i =1; i <= e ; i++ ) {
        let elContainer = document.createElement("div");
        let elLabel = document.createElement("div");
        elContainer.classList.add("el-container");
        elLabel.innerHTML = ` Trait ${i}`;
        elContainer.appendChild(elLabel);
       
        let inputIdEl = document.createElement("input");
        inputIdEl.classList.add("input-id");
        inputIdEl.setAttribute("placeholder"," Input Id");
        inputIdEl.setAttribute("data-user", "inputD" );
        elContainer.appendChild(inputIdEl);

        let inputRatioEl = document.createElement("input");
        inputRatioEl.classList.add("input-ratio");
        inputRatioEl.setAttribute("placeholder"," Input Ratio");
        elContainer.appendChild(inputRatioEl);
        inputContainer.appendChild(elContainer);
    }
}


const Combinaions = (...args) => {
    let result = [], max = args.length - 1;
    const helper = (arr, i) => {
        for (let j = 0, l = args[i].length; j < l; j++) {
            let a = arr.slice(0);
            a.push(args[i][j]);
            if (i == max) {
                result.push(a);
                //  if (Validator(a, result)) {
                //     result.push(a);
                //  }
            }
            else helper(a, i + 1);     
        }
    }
    helper([], 0);
    return result;
}

const Validator = (arr, results) => {
    let _result = true;
    for (let i = arr.length-1 ; i >=0 ; i--) {
        if (NumExistCheck(arr[i], results, i)) _result = false;
    }
    return _result;
}

const NumExistCheck = (num, rs, pos) => {
    let result;
    let arrToTest = targetExistCal[pos];
    let numExist = 0;
    rs.forEach(a => {
        a.forEach(b => {
            if( b == num) numExist += 1;
        })
    })
    let targetPosA = parseInt((num/10).toString()[(num/10).toString().length-1])-1;
    if(numExist > arrToTest[targetPosA]) result = true;
    return result;
}

const Percentage = (a, b) => {
    return (a * b) / 100;
}
const PercentageCal = (arr, num) => {
    let rs = [];
    for (let i = 0; i < arr.length; i++) {
        rs.push(Percentage(arr[i], num))
    }
    return rs;
}
