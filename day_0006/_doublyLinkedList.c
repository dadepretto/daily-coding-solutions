#include <stdlib.h>
#include <stdio.h>

typedef int ValueType;

typedef struct Node
{
    ValueType value;
    struct Node *prev;
    struct Node *next;
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

Node *newNode(ValueType value, Node *prev, Node *next)
{
    Node *node = malloc(sizeof(Node));
    node->value = value;
    node->prev = prev;
    node->next = next;
    return node;
}

void appendItemToList(List *list, ValueType value)
{
    if (list->head == NULL)
    {
        Node *node = newNode(value, NULL, NULL);
        list->head = node;
    }
    else if (list->tail == NULL)
    {
        Node *node = newNode(value, list->head, NULL);
        list->head->next = node;
        list->tail = node;
    }
    else
    {
        Node *node = newNode(value, list->tail, NULL);
        list->tail->next = node;
        list->tail = node;
    }
}

ValueType getValueAtIndex(List *list, int index, short *error)
{
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
            node = node->next;
            i++;
        }
    }

    *error = 1;
    return 0;
}

void printList(List *list)
{
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
        node = node->next;
    }
    printf("]\n");
}

void printListReverse(List *list)
{
    Node *node = list->tail;

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
        node = node->prev;
    }
    printf("]\n");
}

int main()
{
    printf("---------- Doubly linked list ----------\n\n");
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