// You are given a number of eggs, and a number of floors. Find out how the minimum number of tries you need to do, in the worse case scenario
function maxTries(floors, eggs){
	let matrix = [];
	for(let i = 0; i <= eggs; i++){
		matrix.push([]);
	}	
	
	for(let row = 0; row <= eggs; row++){
		for(let col = 0; col <= floors; col++){
			if(row === 0 || col === 0){
				matrix[row].push(0);
				continue;
			}
			else if(row === 1){
				matrix[row].push(col);
				continue;
			}
			
			let min = floors;
			let floorCount = col; 
			let eggsLeft = row; 
			
			for(let f = 1; f <= floorCount; f++){
				let max = 0;	
				
				// egg breaks				
				if(max < matrix[eggsLeft - 1][f - 1]){
					max = matrix[eggsLeft - 1][f - 1];
				}
					
				// egg doesn't break;
				if(max < matrix[eggsLeft][floorCount - f]){
					max = matrix[eggsLeft][floorCount - f];
				}

				if(min > max){
					min = max;
				}
			}
			
			matrix[row].push(min + 1);
		}
	}
	
	console.log(matrix);
	return matrix[eggs][floors];
}

let result = maxTries(6, 2);

console.log(result);
