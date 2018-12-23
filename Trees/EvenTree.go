package main

import (
	"fmt"
)

// Complete the evenForest function below.
func evenForest(t_nodes int, t_edges int, t_from []int, t_to []int) int {
	nodes := make(map[int][]int)
	for i := 0; i < int(t_edges); i++ {
		nodes[t_to[i]] = append(nodes[t_to[i]], t_from[i])
	}

	// start from root - node 1
	// DFS on children
	// if leaf -> return nodes = 1, trees = 0
	// else sum childs' nodes + 1 for the current node, sum childs' trees
	// if sum % 2 = 0 -> a tree was found -> nodes = 0, trees =+ 1
	// return nodes, trees

	_, cuts := DFS(nodes, 1)
	return cuts
}

func DFS(nodes map[int][]int, currentNode int) (int, int) {
	if len(nodes[currentNode]) == 0 {
		return 1, 0
	}

	nodesCount := 1
	cutsCount := 0
	for _, child := range nodes[currentNode] {
		childNodesCount, childCutsCount := DFS(nodes, child)
		nodesCount += childNodesCount
		cutsCount += childCutsCount
	}

	if nodesCount % 2 == 0 {
		nodesCount = 0
		if currentNode != 1 {
			cutsCount += 1
		}
	}

	return nodesCount, cutsCount
}

func main() {
	//tNodes := 10
	//tEdges := 9
	//tFrom := []int {2, 3, 4, 5, 6, 7, 8, 9, 10}
	//tTo := []int {1, 1, 3, 2, 1, 2, 6, 8, 8}

	//tNodes := 2
	//tEdges := 1
	//tFrom := []int {2}
	//tTo := []int {1}

	//tNodes := 5
	//tEdges := 4
	//tFrom := []int {2, 3, 5, 4}
	//tTo := []int {1, 1, 3, 2}

	//tNodes := 6
	//tEdges := 5
	//tFrom := []int {2, 3, 5, 4, 6}
	//tTo := []int {1, 1, 3, 2, 3}

	//tNodes := 7
	//tEdges := 6
	//tFrom := []int {2, 3, 5, 4, 6, 7}
	//tTo := []int {1, 1, 3, 2, 3, 3}

	//tNodes := 8
	//tEdges := 7
	//tFrom := []int {2, 3, 5, 4, 6, 7, 8}
	//tTo := []int {1, 1, 3, 2, 3, 3, 6}

	tNodes := 9
	tEdges := 8
	tFrom := []int {2, 3, 5, 4, 6, 7, 8, 9}
	tTo := []int {1, 1, 3, 2, 3, 3, 6, 3}

	res := evenForest(tNodes, tEdges, tFrom, tTo)

	fmt.Println(res)
}
