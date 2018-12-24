package main

import (
	"fmt"
)

// Complete the roadsAndLibraries function below.
func roadsAndLibraries(n int32, c_lib int32, c_road int32, cities [][]int32) int64 {
	if int64(c_lib) * int64(2) <= int64(c_road) + int64(c_lib) {
		return int64(c_lib) * int64(n)
	}

	// find unconnected graphs count and number of cities in that part
	// create a graph that is a map[int32][]int32 that contains cities and                   
	// what other cities they are connected to
	// create a map of what city has been visited map[int32]bool
	// foreach city in map[int32][]int32, traverse connections and
	// mark as visited in the map[int32][]int32
	// every time you have to stop traversing and enter anew from the top for loop
	// add the count of the cities you have visited in a []int32 and set to 0
	// cost = c_lib * unconnected graphs count (the len of []int32) +
	// c_road * (cities in that part of the graph - 1) or also
	// all cities - unconnected graphs count

	graph := make(map[int32][]int32, n)
	for _, city := range cities {
		graph[city[0]] = append(graph[city[0]], city[1])
		graph[city[1]] = append(graph[city[1]], city[0])
	}

	visited := make(map[int32]bool, n)

	unconnected := n - int32(len(graph))
	for city := range graph {
		if visited[city] {
			continue
		}

		unconnected += 1

		traverse(city , graph, visited)
	}

	cost := int64(c_lib) * int64(unconnected) + int64(c_road) * int64(n - unconnected)

	return int64(cost)
}

func traverse(city int32, graph map[int32][]int32, visited map[int32]bool) {
	if visited[city] {
		return
	}

	visited[city] = true

	if len(graph[city]) == 0 {
		return
	}

	for _, neighbour := range graph[city] {
		traverse(int32(neighbour) , graph, visited)
	}
}

func main() {
	n := int32(6)
	c_lib := int32(2)
	c_road := int32(3)
	var cities [][]int32
	cities = append(cities, []int32 {1, 2})
	cities = append(cities, []int32 {2, 3})
	cities = append(cities, []int32 {4, 5})
	cities = append(cities, []int32 {4, 6})


	result := roadsAndLibraries(n, c_lib, c_road, cities)

	fmt.Print(result)
}
