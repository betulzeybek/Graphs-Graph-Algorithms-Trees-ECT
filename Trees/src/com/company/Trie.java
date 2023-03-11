package com.company;

public class Trie {

    static final int ALPHABET_SIZE = 26;

    static class TrieNode
    {
        TrieNode[] children = new TrieNode[ALPHABET_SIZE];

        boolean isEndOfWord; //Node bir kelimenin sonunu temsil ediyorsa TRUE

        TrieNode(){ //constructor
            isEndOfWord = false;
            for (int i = 0; i < ALPHABET_SIZE; i++)
                children[i] = null;
        }
    }
    static TrieNode root;
    static void insert(String key) //insert metodu
    {
        int level;
        int length = key.length();
        int index;

        TrieNode pCrawl = root;

        for (level = 0; level < length; level++)
        {
            index = key.charAt(level) - 'a';
            if (pCrawl.children[index] == null)
                pCrawl.children[index] = new TrieNode();

            pCrawl = pCrawl.children[index];
        }

        pCrawl.isEndOfWord = true; //son Node' u yaprak olarak işaretler
    }

    public static void main(String args[])
    {
        String keys[] = {"herkese", "merhaba", "ege", "universitesi", "dostlarim", //sadece küçük harflerin kullanışdığı ingiliz alfabesindeki harflerden oluşan kelimeler
                "bye", "bye", "dostlarimm"};

        root = new TrieNode();
        int i;
        for (i = 0; i < keys.length ; i++)
            insert(keys[i]);
        System.out.println(keys[0]);
        System.out.println(keys[1]);
        System.out.println(keys[2]);
        System.out.println(keys[3]);
        System.out.println(keys[4]);
        System.out.println(keys[5]);
        System.out.println(keys[6]);
        System.out.println(keys[7]);
    }
}
