using Xunit;

namespace Day024.Test;

public class NodeTest
{
    [Fact]
    public void Node_GivenValue_ReturnsSameValue()
    {
        var node = new Node<int>(0);

        var actual = node.Value;

        Assert.Equal(0, actual);
    }

    [Fact]
    public void Node_GivenLeftChild_ReturnsLeftChild()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;

        var actual = parent.Left;

        Assert.Equal(leftChild, actual);
    }

    [Fact]
    public void Node_GivenRightChild_ReturnsRightChild()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;

        var actual = parent.Right;

        Assert.Equal(rightChild, actual);
    }

    [Fact]
    public void IsLocked_OnAUnlockedNode_ReturnsFalse()
    {
        var node = new Node<int>(0);

        var actual = node.IsLocked;

        Assert.False(actual);
    }

    [Fact]
    public void IsLocked_OnALockedNode_ReturnsTrue()
    {
        var node = new Node<int>(0);
        node.Lock();

        var actual = node.IsLocked;

        Assert.True(actual);
    }

    [Fact]
    public void Lock_OnASingleUnlockedNode_ReturnsTrue()
    {
        var node = new Node<int>(0);

        var actual = node.Lock();

        Assert.True(actual);
    }

    [Fact]
    public void Lock_OnASingleLockedNode_ReturnsTrue()
    {
        var node = new Node<int>(0);
        node.Lock();

        var actual = node.Lock();

        Assert.True(actual);
    }

    [Fact]
    public void Unlock_OnASingleUnlockedNode_ReturnsTrue()
    {
        var node = new Node<int>(0);

        var actual = node.Unlock();

        Assert.True(actual);
    }

    [Fact]
    public void Unlock_OnASingleLockedNode_ReturnsTrue()
    {
        var node = new Node<int>(0);
        node.Lock();

        var actual = node.Unlock();

        Assert.True(actual);
    }

    [Fact]
    public void Lock_OnLeftChildOfALockedParent_ReturnsFalse()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        parent.Lock();

        var actual = leftChild.Lock();

        Assert.False(actual);
    }

    [Fact]
    public void Lock_OnRightChildOfALockedParent_ReturnsFalse()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        parent.Lock();

        var actual = rightChild.Lock();

        Assert.False(actual);
    }

    [Fact]
    public void Lock_OnParentWithALockedLeftChild_ReturnsFalse()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        leftChild.Lock();

        var actual = parent.Lock();

        Assert.False(actual);
    }

    [Fact]
    public void Lock_OnParentWithALockedRightChild_ReturnsFalse()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        rightChild.Lock();

        var actual = parent.Lock();

        Assert.False(actual);
    }

    [Fact]
    public void Unlock_OnLeftChildOfALockedParent_ReturnsFalse()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        parent.Lock();

        var actual = leftChild.Unlock();

        Assert.False(actual);
    }

    [Fact]
    public void Unlock_OnRightChildOfALockedParent_ReturnsFalse()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        parent.Lock();

        var actual = rightChild.Unlock();

        Assert.False(actual);
    }

    [Fact]
    public void Unlock_OnParentWithALockedLeftChild_ReturnsFalse()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        leftChild.Lock();

        var actual = parent.Unlock();

        Assert.False(actual);
    }

    [Fact]
    public void Unlock_OnParentWithALockedRightChild_ReturnsFalse()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        rightChild.Lock();

        var actual = parent.Unlock();

        Assert.False(actual);
    }

    [Fact]
    public void Unlock_OnLockedParent_LetLeftChildLock()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        parent.Lock();
        parent.Unlock();

        var actual = leftChild.Lock();

        Assert.True(actual);
    }

    [Fact]
    public void Unlock_OnLockedParent_LetRightChildLock()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        parent.Lock();
        parent.Unlock();

        var actual = rightChild.Lock();

        Assert.True(actual);
    }

    [Fact]
    public void Unlock_OnLockedLeftChild_LetParentLock()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        rightChild.Lock();
        rightChild.Unlock();

        var actual = parent.Lock();

        Assert.True(actual);
    }

    [Fact]
    public void Unlock_OnLockedRightChild_LetParentLock()
    {
        var parent = new Node<string>("PARENT");
        var leftChild = new Node<string>("LEFT_CHILD", parent);
        var rightChild = new Node<string>("RIGHT_CHILD", parent);
        parent.Left = leftChild;
        parent.Right = rightChild;
        leftChild.Lock();
        leftChild.Unlock();

        var actual = parent.Lock();

        Assert.True(actual);
    }
}