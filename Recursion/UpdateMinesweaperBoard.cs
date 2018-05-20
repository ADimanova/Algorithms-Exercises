public class Solution {
    /*
    You are given a 2D char matrix representing the game board. 'M' represents an unrevealed mine, 'E' represents an unrevealed empty square, 'B' represents a revealed blank square that has no adjacent (above, below, left, right, and all 4 diagonals) mines, digit ('1' to '8') represents how many mines are adjacent to this revealed square, and finally 'X' represents a revealed mine.

    Now given the next click position (row and column indices) among all the unrevealed squares ('M' or 'E'), return the board after revealing this position according to the following rules:

    If a mine ('M') is revealed, then the game is over - change it to 'X'.
    If an empty square ('E') with no adjacent mines is revealed, then change it to revealed blank ('B') and all of its adjacent unrevealed squares should be revealed recursively.
    If an empty square ('E') with at least one adjacent mine is revealed, then change it to a digit ('1' to '8') representing the number of adjacent mines.
    Return the board when no more squares will be revealed.

    */

    public char[,] UpdateBoard(char[,] board, int[] click) {
        var row = click[0];
        var col = click[1];
        
        Reveal(row, col, board);
        
        return board;
    }
    
    private void Reveal(int row, int col, char[,] board){
        if(row < 0 || col < 0 || row >= board.GetLength(0) || col >= board.GetLength(1)){
            return;
        }
        
        if(board[row, col] == 'M'){
            board[row, col] = 'X';
            return;
        }
        
        if(board[row, col] != 'E'){
            return;
        }
                
        var adjacentMineCount = GetAdjacentMineCount(row, col, board);
        if(adjacentMineCount != 0){
            var numberChar = (char)((int)'0' + adjacentMineCount);
            board[row, col] = numberChar;
        }
        else{
            board[row, col] = 'B';
            Reveal(row - 1, col, board); // North
            Reveal(row + 1, col, board); // South
            Reveal(row, col - 1, board); // West
            Reveal(row, col + 1, board); // East
            Reveal(row - 1, col - 1, board); // North West
            Reveal(row + 1, col + 1, board); // South East
            Reveal(row - 1, col + 1, board); // North East
            Reveal(row + 1, col - 1, board); // South West
        }
    }
    
    private int GetAdjacentMineCount(int row, int col, char[,] board){
        var count = 0;
        
        count = HasMine(row - 1, col, board) ? count + 1 : count; // North
        count = HasMine(row + 1, col, board) ? count + 1 : count; // South
        count = HasMine(row, col - 1, board) ? count + 1 : count; // West
        count = HasMine(row, col + 1, board) ? count + 1 : count; // East
        count = HasMine(row - 1, col - 1, board) ? count + 1 : count; // North West
        count = HasMine(row + 1, col + 1, board) ? count + 1 : count; // South East
        count = HasMine(row - 1, col + 1, board) ? count + 1 : count; // North East
        count = HasMine(row + 1, col - 1, board) ? count + 1 : count; // South West
        
        return count;
    }
    
    private bool HasMine(int row, int col, char[,] board) {
        if(row < 0 || col < 0 || row >= board.GetLength(0) || col >= board.GetLength(1)){
            return false;
        }
        
        return board[row, col] == 'M' || board[row, col] == 'X';
    }    
}
