// make that function availble for other scripts
// export -> expose public API 
// in the file where we will used  ,
//->import {sumNumbers} from './module.js'

//  function sumNumbers(a,b) {
//   return a+b;
// }

// Export multiply 

 function sumNumbers(a,b) {
  return a+b;
}
const myNumber = 6;

export{
  sumNumbers as sumRename,
  myNumber,
}

//->import {sumRename,myNumber} from './module.js'

//Load Everthing

//externalModule is just a name for everthing that u import
//Import * as externalModule from '.module.js'
