package com.example.aniru.bottomnavigationbar;

import java.util.HashMap;
import java.util.Map;

public class Log2 {

    private String UID;
    private Integer Time, Light2;

    public Log2(){
        // Default constructor required for calls to DataSnapshot.getValue(Post.class)
    }

    public Log2(String UID, Integer Time,Integer Light2) {
        this.UID = UID;
        this.Time = Time;
        this.Light2=Light2;

    }

    public Map<String, Object> toMap() {
        HashMap<String, Object> result = new HashMap<>();

        result.put("UID",UID);
        result.put("Time",Time);
        result.put("Light2",Light2);

        return result;
    }

    public String getUID() {
        return UID;
    }

    public Integer getTime() {
        return Time;
    }

    public Integer getLight2() {
        return Light2;
    }
}
