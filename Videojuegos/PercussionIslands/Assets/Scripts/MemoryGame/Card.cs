//This Script contains
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    // Start is called before the first frame update
    public class Card{
        public bool isImage;
        public int id;
        public Sprite img;
        public AudioClip snd;
        //Constructor
        public Card(int _id,Sprite _img){
            this.id = _id;
            this.isImage = true;
            this.img = _img;
        }
        public Card(int _id, AudioClip _snd){
            this.id = _id;
            this.isImage = false;
            this.snd = _snd;
        }
    }

