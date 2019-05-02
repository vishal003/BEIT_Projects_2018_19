package com.example.aniru.bottomnavigationbar;

import java.util.HashMap;
import java.util.Map;

public class Retriever {

    private Integer day,time, light1,light2,light3,light4;

    public Retriever(){
        // Default constructor required for calls to DataSnapshot.getValue(Post.class)
    }

    public Retriever(Integer day,Integer time,Integer light1,Integer light2,Integer light3,Integer light4) {
        //this.ID=ID;
        this.day=day;
        this.time = time;
        this.light1=light1;
        this.light2=light2;
        this.light3=light3;
        this.light4=light4;
    }
    public Map<String, Object> toMap() {
        HashMap<String, Object> result = new HashMap<>();
        //result.put("ID",ID);
        result.put("day",day);
        result.put("time",time);
        result.put("light 1",light1);
        result.put("light 2",light2);
        result.put("light 3",light3);
        result.put("light 4",light4);

        return result;
    }

    //public Integer getID(){return ID;}
    Integer getDay(){return day;}
    public Integer getTime() {
        return time;
    }
    Integer getLight1() {
        return light1;
    }
    Integer getLight2() {
        return light2;
    }
    Integer getLight3() {
        return light3;
    }
    Integer getLight4() {
        return light4;
    }
}
