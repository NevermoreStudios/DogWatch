package com.nevermore.dogwatch;

import android.app.Activity;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.Scanner;

public class MainActivity extends Activity {

    TextView info, status;
    ImageView dog, bowl;
    HttpTask task;

    class Info {
        public String status, info;
        public int res;
        public Info(String status, String info, int res) {
            this.status = status;
            this.info = info;
            this.res = res;
        }
    }

    final Info[] INFO = new Info[] {
            new Info("FULL", "Don't worry, your dog must be fine!", R.drawable.dog_0),
            new Info("HALF-FULL", "Your dog is still happy!", R.drawable.dog_1),
            new Info("ALMOST EMPTY", "You should pour some more water into the bowl!", R.drawable.dog_2),
            new Info("EMPTY", "Oh, my. Your dog must be thirsty!", R.drawable.dog_3)
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        info = (TextView)findViewById(R.id.bowl_info);
        status = (TextView)findViewById(R.id.bowl_status);
        dog = (ImageView)findViewById(R.id.dog);
        bowl = (ImageView)findViewById(R.id.bowl);
        dog.setImageResource(R.drawable.drink);
        task = new HttpTask();
        task.execute();
    }

    private void refresh() {
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                task = new HttpTask();
                task.execute();
            }
        }, 5000);
    }

    private void doStuff(JSONObject o) {
        try {
            boolean drinking = o.getBoolean("drinking");
            int state = Integer.parseInt(o.getString("status"));
            Info data = INFO[state];
            status.setText(data.status);
            info.setText(data.info);
            bowl.setImageResource(data.res);
            if(drinking) {
                dog.setVisibility(View.VISIBLE);
            } else {
                dog.setVisibility(View.INVISIBLE);
            }
            this.refresh();
        } catch(JSONException e) {
            // rip
        }
    }

    public class HttpTask extends AsyncTask<Void, Void, JSONObject> {

        @Override
        protected JSONObject doInBackground(Void... params) {
            try {
                URL url = new URL("http://192.168.1.40/?json");
                HttpURLConnection urlConnection = (HttpURLConnection)url.openConnection();
                Scanner s = new Scanner(
                        new BufferedInputStream(
                                urlConnection.getInputStream()
                        )
                );
                return new JSONObject(s.hasNext() ? s.next() : "{}");
            } catch(JSONException |IOException e) {
                e.printStackTrace();
                return null;
            }
        }

        @Override
        protected void onPostExecute(JSONObject o) {
            doStuff(o);
        }
    }

}
