#include <stdlib.h>
#include <stdio.h>

typedef int ValueType;

typedef struct Node
{
    ValueType value;
    uintptr_t xorPrevNext;
} Node;

typedef struct List
{
    Node *head;
    Node *tail;
} List;

List *newList()
{
    List *list = malloc(sizeof(List));
    list->head = NULL;
    list->tail = NULL;
    return list;
}

uintptr_t xorPrevNext(Node *prev, Node *next)
{
    return (uintptr_t)prev ^ (uintptr_t)next;
}

Node *getPrev(uintptr_t xorPrevNext, Node *next)
{
    return (Node *)((uintptr_t)xorPrevNext ^ (uintptr_t)next);
}

Node *getNext(uintptr_t xorPrevNext, Node *prev)
{
    return (Node *)((uintptr_t)xorPrevNext ^ (uintptr_t)prev);
}

Node *newNode(ValueType value, uintptr_t xorPrevNext)
{
    Node *node = malloc(sizeof(Node));
    node->value = value;
    node->xorPrevNext = xorPrevNext;
    return node;
}

void appendItemToList(List *list, ValueType value)
{
    if (list->head == NULL)
    {
        Node *node = newNode(value, xorPrevNext(NULL, NULL));
        list->head = node;
    }
    else if (list->tail == NULL)
    {
        Node *node = newNode(value, xorPrevNext(list->head, NULL));
        list->head->xorPrevNext = xorPrevNext(NULL, node);
        list->tail = node;
    }
    else
    {
        Node *node = newNode(value, xorPrevNext(list->tail, NULL));
        Node *prev = getPrev(list->tail->xorPrevNext, NULL);
        list->tail->xorPrevNext = xorPrevNext(prev, node);
        list->tail = node;
    }
}

ValueType getValueAtIndex(List *list, int index, short *error)
{
    Node *prev = NULL;
    Node *node = list->head;

    if (list->head == NULL)
    {
        *error = 1;
        return 0;
    }

    *error = 0;
    int i = 0;
    while (i <= index && node != NULL)
    {
        if (i == index)
        {
            return node->value;
        }
        else
        {
            Node *temp = node;
            node = getNext(node->xorPrevNext, prev);
            prev = temp;
            i++;
        }
    }

    *error = 1;
    return 0;
}

void printList(List *list)
{
    Node *prev = NULL;
    Node *node = list->head;

    if (node == NULL)
    {
        printf("[]\n");
        return;
    }

    printf("[ ");
    while (node != NULL)
    {
        printf("%d ", node->value);
        Node *temp = node;
        node = getNext(node->xorPrevNext, prev);
        prev = temp;
    }
    printf("]\n");
}

void printListReverse(List *list)
{
    Node *node = list->tail;
    Node *next = NULL;

    if (node == NULL)
    {
        node = list->head;
    }

    if (node == NULL)
    {
        printf("[]\n");
        return;
    }

    printf("[ ");
    while (node != NULL)
    {
        printf("%d ", node->value);
        Node *temp = node;
        node = getPrev(node->xorPrevNext, next);
        next = temp;
    }
    printf("]\n");
}

int main()
{
    printf("---------- XOR Doubly linked list ----------\n\n");
    List *list = newList();
    printList(list);
    printListReverse(list);
    appendItemToList(list, 10);
    printList(list);
    printListReverse(list);
    appendItemToList(list, 20);
    printList(list);
    printListReverse(list);
    appendItemToList(list, 30);
    printList(list);
    printListReverse(list);

    int indexes[] = {-1, 0, 1, 2, 3};

    for (int i = 0; i < 5; i++)
    {
        short error;
        ValueType value = getValueAtIndex(list, indexes[i], &error);
        if (error == 0)
            printf("list[%d]: %d\n", indexes[i], value);
        else
            printf("list[%d]: Index not found!\n", indexes[i]);
    }
}