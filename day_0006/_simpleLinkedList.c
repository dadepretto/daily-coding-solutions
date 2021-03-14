#include <stdlib.h>
#include <stdio.h>

typedef int ValueType;

typedef struct Node
{
    ValueType value;
    struct Node *next;
} Node;

typedef struct List
{
    Node *head;
} List;

List *newList()
{
    List *list = malloc(sizeof(List));
    list->head = NULL;
    return list;
}

Node *newNode(ValueType value, Node *next)
{
    Node *node = malloc(sizeof(Node));
    node->value = value;
    node->next = next;
    return node;
}

void appendItemToList(List *list, ValueType value)
{
    Node *node = list->head;
    Node *new = newNode(value, NULL);

    if (node == NULL)
        list->head = new;
    else
    {
        while (node->next != NULL)
            node = node->next;

        node->next = new;
    }
}

ValueType getValueAtIndex(List *list, int index, short *error)
{
    Node *node = list->head;

    if (node == NULL)
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

int main()
{
    printf("---------- Simple linked list ----------\n\n");
    List *list = newList();
    printList(list);
    appendItemToList(list, 10);
    printList(list);
    appendItemToList(list, 20);
    printList(list);
    appendItemToList(list, 30);
    printList(list);

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