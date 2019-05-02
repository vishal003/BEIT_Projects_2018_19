package com.example.aniru.bottomnavigationbar;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.List;

public class RecyclerviewAdapter extends RecyclerView.Adapter<RecyclerviewAdapter.MyViewHolder> {

    List<Retriever> retrievers;
    Context context;

    public RecyclerviewAdapter (Context context,List<Retriever> retrievers){
        this.context=context;
        this.retrievers=retrievers;

    }

    @NonNull
    @Override
    public RecyclerviewAdapter.MyViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        View itemView = LayoutInflater.from(context).inflate(R.layout.layout_with_child, viewGroup,false);
        return new RecyclerviewAdapter.MyViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerviewAdapter.MyViewHolder myViewHolder, int i) {
        myViewHolder.Day.setText(retrievers.get(i).getDay());
        myViewHolder.Time.setText(retrievers.get(i).getTime());
        myViewHolder.Light1.setText(retrievers.get(i).getLight1());
        myViewHolder.Light2.setText(retrievers.get(i).getLight2());
        myViewHolder.Light3.setText(retrievers.get(i).getLight3());
        myViewHolder.Light4.setText(retrievers.get(i).getLight4());
    }

    @Override
    public int getItemCount() {
        return retrievers.size();
    }

    public static class MyViewHolder extends RecyclerView.ViewHolder {
        TextView Day,Time,Light1,Light2,Light3,Light4;
        public MyViewHolder(@NonNull View itemView) {
            super(itemView);

            Day=itemView.findViewById(R.id.subtextDay);
            Time=itemView.findViewById(R.id.subtextTime);
            Light1=itemView.findViewById(R.id.subtextItemL1);
            Light2=itemView.findViewById(R.id.subtextItemL2);
            Light3=itemView.findViewById(R.id.subtextItemL3);
            Light4=itemView.findViewById(R.id.subtextItemL4);


        }
    }
}
