package com.example.aniru.bottomnavigationbar;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CompoundButton;
import android.widget.Switch;
import android.widget.Toast;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.analytics.FirebaseAnalytics;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;
import java.text.SimpleDateFormat;
import java.util.Date;
/**
 * A simple {@link Fragment} subclass.
 */
public class HomeFragment extends Fragment {
    long maxid = 0;

    public HomeFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_home, container, false);

        return v;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        Switch light1,light2,light3,light4;

        light1 = getView().findViewById(R.id.Light1);
        light2 = getView().findViewById(R.id.Light2);
        light3 = getView().findViewById(R.id.Light3);
        light4 = getView().findViewById(R.id.Light4);

        light1.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                final   FirebaseAnalytics mFirebaseAnalytics;
// ..
// Obtain the FirebaseAnalytics instance.
                mFirebaseAnalytics = FirebaseAnalytics.getInstance(getActivity());
                if(isChecked){

                    final FirebaseDatabase database = FirebaseDatabase.getInstance();
                    DatabaseReference myRef = database.getReference("Light1");
                    myRef.setValue(1);

                    DatabaseReference myRef1 = database.getReference("override");
                    myRef1.setValue(0);
                    DatabaseReference Ref = database.getReference("/");

                    DatabaseReference logRef = Ref.child("LOG");

                    logRef.addValueEventListener(new ValueEventListener() {
                        @Override
                        public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                            if(dataSnapshot.exists()){
                                maxid=(dataSnapshot.getChildrenCount());
                            }
                        }

                        @Override
                        public void onCancelled(@NonNull DatabaseError databaseError) {

                        }
                    });

                    SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
                    int s = Integer.parseInt(sdf.format(new Date()).replace(":"," "));

                    String UID = FirebaseAuth.getInstance().getCurrentUser().getUid();
                    Log1 log1 = new Log1(UID,s,1);
                    logRef.child(String.valueOf(maxid+1)).setValue(log1).addOnCompleteListener(new OnCompleteListener<Void>() {
                        @Override
                        public void onComplete(@NonNull Task<Void> task) {
                            if(task.isSuccessful()){
                                Toast.makeText(getActivity(), "Log Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                            }
                            else {
                                Toast.makeText(getActivity(), "Log NOT Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                                return;
                            }

                        }
                    });
                }else {
                    FirebaseDatabase database = FirebaseDatabase.getInstance();
                    DatabaseReference myRef = database.getReference("Light1");
                    myRef.setValue(0);

                    DatabaseReference Ref = database.getReference("/");

                    DatabaseReference logRef = Ref.child("LOG");

                    logRef.addValueEventListener(new ValueEventListener() {
                        @Override
                        public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                            if(dataSnapshot.exists()){
                                maxid=(dataSnapshot.getChildrenCount());
                            }
                        }

                        @Override
                        public void onCancelled(@NonNull DatabaseError databaseError) {

                        }
                    });

                    SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
                    int s = Integer.parseInt(sdf.format(new Date()).replace(":"," "));

                    String UID = FirebaseAuth.getInstance().getCurrentUser().getUid();
                    Log1 log1 = new Log1(UID,s,0);
                    logRef.child(String.valueOf(maxid+1)).setValue(log1).addOnCompleteListener(new OnCompleteListener<Void>() {
                        @Override
                        public void onComplete(@NonNull Task<Void> task) {
                            if(task.isSuccessful()){
                                Toast.makeText(getActivity(), "Log Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                            }
                            else {
                                Toast.makeText(getActivity(), "Log NOT Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                                return;
                            }

                        }
                    });


                }

            }
        });

        light2.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {

                if(isChecked){

                    FirebaseDatabase database = FirebaseDatabase.getInstance();
                    DatabaseReference myRef = database.getReference("Light2");

                    myRef.setValue(1);
                    DatabaseReference myRef1 = database.getReference("override");
                    myRef1.setValue(0);
                    DatabaseReference Ref = database.getReference("/");

                    DatabaseReference logRef = Ref.child("LOG");

                    logRef.addValueEventListener(new ValueEventListener() {
                        @Override
                        public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                            if(dataSnapshot.exists()){
                                maxid=(dataSnapshot.getChildrenCount());
                            }
                        }

                        @Override
                        public void onCancelled(@NonNull DatabaseError databaseError) {

                        }
                    });

                    SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
                    int s = Integer.parseInt(sdf.format(new Date()).replace(":"," "));

                    String UID = FirebaseAuth.getInstance().getCurrentUser().getUid();
                    Log2 log2 = new Log2(UID,s,1);

                    logRef.child(String.valueOf(maxid+1)).setValue(log2).addOnCompleteListener(new OnCompleteListener<Void>() {
                        @Override
                        public void onComplete(@NonNull Task<Void> task) {
                            if(task.isSuccessful()){
                                Toast.makeText(getActivity(), "Log Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                            }
                            else {
                                Toast.makeText(getActivity(), "Log NOT Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                                return;
                            }

                        }
                    });

                }else {


                    FirebaseDatabase database = FirebaseDatabase.getInstance();
                    DatabaseReference myRef = database.getReference("Light2");

                    myRef.setValue(0);
                    DatabaseReference Ref = database.getReference("/");

                    DatabaseReference logRef = Ref.child("LOG");

                    logRef.addValueEventListener(new ValueEventListener() {
                        @Override
                        public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                            if(dataSnapshot.exists()){
                                maxid=(dataSnapshot.getChildrenCount());
                            }
                        }

                        @Override
                        public void onCancelled(@NonNull DatabaseError databaseError) {

                        }
                    });

                    SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
                    int s = Integer.parseInt(sdf.format(new Date()).replace(":"," "));

                    String UID = FirebaseAuth.getInstance().getCurrentUser().getUid();
                    Log2 log2 = new Log2(UID,s,0);
                    logRef.child(String.valueOf(maxid+1)).setValue(log2).addOnCompleteListener(new OnCompleteListener<Void>() {
                        @Override
                        public void onComplete(@NonNull Task<Void> task) {
                            if(task.isSuccessful()){
                                Toast.makeText(getActivity(), "Log Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                            }
                            else {
                                Toast.makeText(getActivity(), "Log NOT Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                                return;
                            }

                        }
                    });

                }

            }
        });

        light3.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {

                if(isChecked){

                    FirebaseDatabase database = FirebaseDatabase.getInstance();
                    DatabaseReference myRef = database.getReference("Light3");

                    myRef.setValue(1);
                    DatabaseReference myRef1 = database.getReference("override");
                    myRef1.setValue(0);

                    DatabaseReference Ref = database.getReference("/");

                    DatabaseReference logRef = Ref.child("LOG");

                    logRef.addValueEventListener(new ValueEventListener() {
                        @Override
                        public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                            if(dataSnapshot.exists()){
                                maxid=(dataSnapshot.getChildrenCount());
                            }
                        }

                        @Override
                        public void onCancelled(@NonNull DatabaseError databaseError) {

                        }
                    });

                    SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
                    int s = Integer.parseInt(sdf.format(new Date()).replace(":"," "));

                    String UID = FirebaseAuth.getInstance().getCurrentUser().getUid();
                    Log3 log3 = new Log3(UID,s,1);
                    logRef.child(String.valueOf(maxid+1)).setValue(log3).addOnCompleteListener(new OnCompleteListener<Void>() {
                        @Override
                        public void onComplete(@NonNull Task<Void> task) {
                            if(task.isSuccessful()){
                                Toast.makeText(getActivity(), "Log Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                            }
                            else {
                                Toast.makeText(getActivity(), "Log NOT Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                                return;
                            }

                        }
                    });



                }else {


                    FirebaseDatabase database = FirebaseDatabase.getInstance();
                    DatabaseReference myRef = database.getReference("Light3");

                    myRef.setValue(0);

                    DatabaseReference Ref = database.getReference("/");

                    DatabaseReference logRef = Ref.child("LOG");

                    logRef.addValueEventListener(new ValueEventListener() {
                        @Override
                        public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                            if(dataSnapshot.exists()){
                                maxid=(dataSnapshot.getChildrenCount());
                            }
                        }

                        @Override
                        public void onCancelled(@NonNull DatabaseError databaseError) {

                        }
                    });

                    SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
                    int s = Integer.parseInt(sdf.format(new Date()).replace(":"," "));

                    String UID = FirebaseAuth.getInstance().getCurrentUser().getUid();
                    Log3 log3 = new Log3(UID,s,0);
                    logRef.child(String.valueOf(maxid+1)).setValue(log3).addOnCompleteListener(new OnCompleteListener<Void>() {
                        @Override
                        public void onComplete(@NonNull Task<Void> task) {
                            if(task.isSuccessful()){
                                Toast.makeText(getActivity(), "Log Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                            }
                            else {
                                Toast.makeText(getActivity(), "Log NOT Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                                return;
                            }

                        }
                    });


                }

            }
        });

        light4.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {

                if(isChecked){

                    FirebaseDatabase database = FirebaseDatabase.getInstance();
                    DatabaseReference myRef = database.getReference("Light4");

                    myRef.setValue(1);

                    DatabaseReference myRef1 = database.getReference("override");
                    myRef1.setValue(0);
                    DatabaseReference Ref = database.getReference("/");

                    DatabaseReference logRef = Ref.child("LOG");

                    logRef.addValueEventListener(new ValueEventListener() {
                        @Override
                        public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                            if(dataSnapshot.exists()){
                                maxid=(dataSnapshot.getChildrenCount());
                            }
                        }

                        @Override
                        public void onCancelled(@NonNull DatabaseError databaseError) {

                        }
                    });

                    SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
                    int s = Integer.parseInt(sdf.format(new Date()).replace(":"," "));

                    String UID = FirebaseAuth.getInstance().getCurrentUser().getUid();
                    Log4 log4 = new Log4(UID,s,1);
                    logRef.child(String.valueOf(maxid+1)).setValue(log4).addOnCompleteListener(new OnCompleteListener<Void>() {
                        @Override
                        public void onComplete(@NonNull Task<Void> task) {
                            if(task.isSuccessful()){
                                Toast.makeText(getActivity(), "Log Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                            }
                            else {
                                Toast.makeText(getActivity(), "Log NOT Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                                return;
                            }

                        }
                    });

                }else {


                    FirebaseDatabase database = FirebaseDatabase.getInstance();
                    DatabaseReference myRef = database.getReference("Light4");

                    myRef.setValue(0);
                    DatabaseReference Ref = database.getReference("/");

                    DatabaseReference logRef = Ref.child("LOG");

                    logRef.addValueEventListener(new ValueEventListener() {
                        @Override
                        public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                            if(dataSnapshot.exists()){
                                maxid=(dataSnapshot.getChildrenCount());
                            }
                        }

                        @Override
                        public void onCancelled(@NonNull DatabaseError databaseError) {

                        }
                    });

                    SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
                    int s = Integer.parseInt(sdf.format(new Date()).replace(":"," "));

                    String UID = FirebaseAuth.getInstance().getCurrentUser().getUid();
                    Log4 log4 = new Log4(UID,s,0);
                    logRef.child(String.valueOf(maxid+1)).setValue(log4).addOnCompleteListener(new OnCompleteListener<Void>() {
                        @Override
                        public void onComplete(@NonNull Task<Void> task) {
                            if(task.isSuccessful()){
                                Toast.makeText(getActivity(), "Log Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                            }
                            else {
                                Toast.makeText(getActivity(), "Log NOT Created" + task.getException(),
                                        Toast.LENGTH_SHORT).show();
                                return;
                            }

                        }
                    });

                }

            }
        });


    }
}