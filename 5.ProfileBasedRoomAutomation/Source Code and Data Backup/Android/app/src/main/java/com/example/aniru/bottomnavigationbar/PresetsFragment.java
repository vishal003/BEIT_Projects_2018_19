package com.example.aniru.bottomnavigationbar;


        import android.os.Bundle;
        import android.support.annotation.NonNull;
        import android.support.annotation.Nullable;
        import android.support.v4.app.Fragment;
        import android.view.LayoutInflater;
        import android.view.View;
        import android.view.ViewGroup;
        import android.widget.AdapterView;
        import android.widget.ArrayAdapter;
        import android.widget.Button;
        import android.widget.Spinner;
        import android.widget.Toast;

        import com.google.android.gms.tasks.OnCompleteListener;
        import com.google.android.gms.tasks.Task;
        import com.google.firebase.auth.FirebaseAuth;
        import com.google.firebase.database.DataSnapshot;
        import com.google.firebase.database.DatabaseError;
        import com.google.firebase.database.DatabaseReference;
        import com.google.firebase.database.FirebaseDatabase;
        import com.google.firebase.database.ValueEventListener;

        import java.util.ArrayList;
        import java.util.List;


/**
 * A simple {@link Fragment} subclass.
 */
public class PresetsFragment extends Fragment  {

    Integer day,time,lights1,lights2,lights3,lights4;
    long maxid = 0;
    Spinner Day,Time,l1,l2,l3,l4;
    Button submit;

    public PresetsFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_presets, container, false);

    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);


        Day =  getView().findViewById(R.id.daySpinner);
        Time = getView().findViewById(R.id.timeSpinner);
        l1 = getView().findViewById(R.id.light1Spinner);
        l2 = getView().findViewById(R.id.light2Spinner);
        l3 = getView().findViewById(R.id.light3Spinner);
        l4 = getView().findViewById(R.id.light4Spinner);
        submit = getView().findViewById(R.id.submitButton);
        final FirebaseDatabase database = FirebaseDatabase.getInstance();



        //Spinner Click Listener
        /*Day.setOnItemSelectedListener((AdapterView.OnItemSelectedListener) this);
        Time.setOnItemSelectedListener((AdapterView.OnItemSelectedListener) this);
        l1.setOnItemSelectedListener((AdapterView.OnItemSelectedListener) this);
        l2.setOnItemSelectedListener((AdapterView.OnItemSelectedListener) this);
        l3.setOnItemSelectedListener((AdapterView.OnItemSelectedListener) this);
        l4.setOnItemSelectedListener((AdapterView.OnItemSelectedListener) this);
*/
        //List for days input
        List<Integer> days = new ArrayList<Integer>();
        days.add(1);
        days.add(2);
        days.add(3);
        days.add(4);
        days.add(5);

        //List for time input
        List<Integer> times = new ArrayList<Integer>();
        times.add(900);
        times.add(1000);
        times.add(1100);
        times.add(1200);
        times.add(1300);
        times.add(1400);
        times.add(1500);
        times.add(1600);

        //List of Light1 Input
        List<Integer> lit1 = new ArrayList<Integer>();
        lit1.add(1);
        lit1.add(0);

        //List of Light 2 Input
        List<Integer> lit2 = new ArrayList<Integer>();
        lit2.add(1);
        lit2.add(0);

        //List of Light 3 Input
        List<Integer> lit3 = new ArrayList<Integer>();
        lit3.add(1);
        lit3.add(0);

        //List of Light 4 Input
        List<Integer> lit4 = new ArrayList<Integer>();
        lit4.add(1);
        lit4.add(0);

        //Creating Adapter for Spinners

        ArrayAdapter<Integer> daysAdapter = new ArrayAdapter<Integer>(getActivity(),android.R.layout.simple_spinner_item,days);
        ArrayAdapter<Integer> timesAdapter = new ArrayAdapter<Integer>(getActivity(),android.R.layout.simple_spinner_item,times);
        ArrayAdapter<Integer> lit1Adapter = new ArrayAdapter<Integer>(getActivity(),android.R.layout.simple_spinner_item,lit1);
        ArrayAdapter<Integer> lit2Adapter = new ArrayAdapter<Integer>(getActivity(),android.R.layout.simple_spinner_item,lit2);
        ArrayAdapter<Integer> lit3Adapter = new ArrayAdapter<Integer>(getActivity(),android.R.layout.simple_spinner_item,lit3);
        ArrayAdapter<Integer> lit4Adapter = new ArrayAdapter<Integer>(getActivity(),android.R.layout.simple_spinner_item,lit4);

        // Drop down layout style - list view with radio button
        daysAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        timesAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        lit1Adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        lit2Adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        lit3Adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        lit4Adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        // attaching data adapter to spinner
        Day.setAdapter(daysAdapter);
        Time.setAdapter(timesAdapter);
        l1.setAdapter(lit1Adapter);
        l2.setAdapter(lit2Adapter);
        l3.setAdapter(lit3Adapter);
        l4.setAdapter(lit4Adapter);

        day = (Integer) Day.getSelectedItem();
        time = (Integer) Time.getSelectedItem();
        lights1 = (Integer) l1.getSelectedItem();
        lights2 = (Integer) l2.getSelectedItem();
        lights3 = (Integer) l3.getSelectedItem();
        lights4 = (Integer) l4.getSelectedItem();


        submit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String UID = FirebaseAuth.getInstance().getCurrentUser().getUid();

                day = (Integer) Day.getSelectedItem();
                time = (Integer) Time.getSelectedItem();
                lights1 = (Integer) l1.getSelectedItem();
                lights2 = (Integer) l2.getSelectedItem();
                lights3 = (Integer) l3.getSelectedItem();
                lights4 = (Integer) l4.getSelectedItem();

                /*Toast.makeText(getActivity(), "Day "+ day.toString(), Toast.LENGTH_LONG).show();
                Toast.makeText(getActivity(), "time "+ time.toString(), Toast.LENGTH_LONG).show();
                Toast.makeText(getActivity(), "light 1 "+ lights1.toString(), Toast.LENGTH_LONG).show();*/
                FirebaseDatabase database = FirebaseDatabase.getInstance();
                DatabaseReference Ref = database.getReference("/");
                DatabaseReference logRef = Ref.child("Preferences");

                logRef.child(UID).addValueEventListener(new ValueEventListener() {
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



                Preference preference = new Preference(UID,lights1,lights2,lights3,lights4);

              /*  logRef.child(UID).child(String.valueOf(maxid+1)).setValue(preference).addOnCompleteListener(new OnCompleteListener<Void>() {
                    @Override
                    public void onComplete(@NonNull Task<Void> task) {
                        if(task.isSuccessful()){
                            Toast.makeText(getActivity(), "Preference Created" + task.getException(),
                                    Toast.LENGTH_SHORT).show();
                        }
                        else {
                            Toast.makeText(getActivity(), "Preference NOT Created" + task.getException(),
                                    Toast.LENGTH_SHORT).show();
                            return;
                        }

                    }
                });*/

                logRef.child(String.valueOf(day)).child(String.valueOf(time)).setValue(preference).addOnCompleteListener(new OnCompleteListener<Void>() {
                    @Override
                    public void onComplete(@NonNull Task<Void> task) {
                        if(task.isSuccessful()){
                            Toast.makeText(getActivity(), "Preference Created" + task.getException(),
                                    Toast.LENGTH_SHORT).show();
                        }
                        else {
                            Toast.makeText(getActivity(), "Preference NOT Created" + task.getException(),
                                    Toast.LENGTH_SHORT).show();
                            return;
                        }

                    }
                });

            }
        });















    }
}
