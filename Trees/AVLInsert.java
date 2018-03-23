   /* Class node is defined as :
    class Node 
       int val;   //Value
       int ht;      //Height
       Node left;   //Left child
       Node right;   //Right child

   */


static Node insert(Node node, int val){
    if(node.val > val){
        if(node.left != null){
            node.left = insert(node.left, val);
        }
        else{
            node.left = new Node();
            node.left.val = val;
        }
    }
    else {
        if(node.right != null){
            node.right = insert(node.right, val);
        }
        else{
            node.right = new Node();
            node.right.val = val;
        }
    }
    
    node.ht = calculateNodeHeight(node);
    int balance = calculateBalance(node);
    
    if(balance > 1 || balance < -1){
        node = rebalance(node, balance);
        node.ht = calculateNodeHeight(node);
    }
    
    return node;
}

static Node rebalance(Node node, int balance){
    
    if(balance > 0){
        int rightBalance = calculateBalance(node.right);
        if(rightBalance > 0){
            return rightRight(node);
        }
        else{
            return rightLeft(node);
        }
    }
    else {
        int leftBalance = calculateBalance(node.left);
        if(leftBalance < 0){
            return leftLeft(node);
        }
        else{
            return leftRight(node);
        }
    }
}

static Node rightRight(Node node){    
    Node topNode = node.right;
    node.right = topNode.left;
    topNode.left = node;
    
    topNode.ht = calculateNodeHeight(topNode);
    node.ht = calculateNodeHeight(node);
    
    return topNode;
}

static Node leftLeft(Node node){
    Node topNode = node.left;
    node.left = topNode.right;
    topNode.right = node;
    
    topNode.ht = calculateNodeHeight(topNode);
    node.ht = calculateNodeHeight(node);
    
    return topNode;
}


static Node rightLeft(Node node){
    Node temp = node.right;
    node.right = node.right.left;
    temp.left = node.right.right;
    node.right.right = temp;
    
    node.right.right.ht = calculateNodeHeight(node.right.right);
    node.right.ht = calculateNodeHeight(node.right);
    
    return rightRight(node);
}

static Node leftRight(Node node){
    Node temp = node.left;
    node.left = node.left.right;
    temp.right = node.left.left;
    node.left.left = temp;
    
    node.left.left.ht = calculateNodeHeight(node.left.left);
    node.left.ht = calculateNodeHeight(node.left);
    
    return leftLeft(node);
}

static int calculateBalance(Node node){
    int balance = 0;
    if(node.ht == 0){
        balance = 0;
    }    
    else if(node.right == null){
        balance = -1 - node.left.ht;
    }
    else if (node.left == null){
        balance = node.right.ht + 1;
    }
    else{
        balance = node.right.ht - node.left.ht;
    }
    
    return balance;
}

static int calculateNodeHeight(Node node){
    if(node.left != null && node.right != null){
        int maxHt = node.left.ht > node.right.ht ? node.left.ht : node.right.ht;
        return maxHt + 1;
    }
    else if (node.left != null){
        return node.left.ht + 1;
    }
    else if(node.right != null){
        return node.right.ht + 1;
    }
    else{
        return 0;
    }
}
